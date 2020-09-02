using UnityEngine;

public class Araba : MonoBehaviour
{
    Vector3 targetPosition;
    SingletonPath path;
    public float moveSpeed = 5f;
    public bool looping=true;
    public bool isBlueCar;
    bool isPathSwitched=false;
    private float time = 0.0f;
    public float repeatTime = 0.1f;
    void Start()
    {
        path = SingletonPath.Instance;
        if (isBlueCar)
        {
            targetPosition = path.getBluePoint(isPathSwitched);
        }
        else
        {
            targetPosition = path.getRedPoint(isPathSwitched);
        }
        
    }

    
    void Update()
    {
        time += Time.deltaTime;
        float distance = Vector3.Distance(targetPosition, transform.position);
        if(distance < 0.1f)
        {
            SetNewTargetPosition();
        }
        SetLookRotation();
        GotoTarget();
    }

    private void SetLookRotation()
    {
        Vector3 dir = targetPosition - transform.position;
        dir.Normalize();
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime * 10f);
    }

    private void GotoTarget()
    {

        if (isBlueCar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPathSwitched = !isPathSwitched;
                path.switchSides(isBlueCar);
            }
        }
        else
        {
            repeatTime = Random.Range(3f, 5f);
            if (time >= repeatTime)
            {
                time = 0.0f;
                isPathSwitched = !isPathSwitched;
                path.switchSides(isBlueCar);
            }

        }
        if (Vector3.Distance(targetPosition, transform.position) < 0.1f) return;
        Vector3 dir = targetPosition - transform.position;
        dir.Normalize();
        transform.position += dir * moveSpeed *Time.deltaTime;
    }

    private void SetNewTargetPosition()
    {
        
            if (isBlueCar)
            {
                targetPosition = path.getBluePoint(isPathSwitched);
            }
            else
            {
                targetPosition = path.getRedPoint(isPathSwitched);
            }
       
         
        if (looping)
        {
            if (isBlueCar) {
                if (path.BlueIndex == path.blueGetLength() - 1)
                {
                    path.resetIndex(isBlueCar);
                }
            } else
            {
                if (path.RedIndex == path.redGetLength() - 1)
                {
                    path.resetIndex(isBlueCar);
                }
            }
            
        }

        path.updateIndex(isBlueCar,isPathSwitched);

    }
}
