using UnityEngine;

public class Bot : MonoBehaviour
{
    Path path;
    public GameObject player;
    Vector3 targetPosition;
    int index;
    public float moveSpeed = 4f;
    public bool looping;
    bool isPlayerDetected = false;
    float delayed=0f;
    public float FieldOfView = 360;
    public float fireDistance = 5f;
    [Range(0.1f, 0.8f)]
    public float fireSpeed = 0.5f;
    public float maxCheckDistance = 15;
    public Rigidbody bombPrefab;
    public Transform bombSpawnP;
    [Range(2000f, 10000f)]
    public float bombSpeed = 2000f;

    void Start()
    {
        path = GameObject.FindObjectOfType<Path>();
        targetPosition = path.getPoint(index);
    }


    void Update()
    {
        float distance = Vector3.Distance(targetPosition, transform.position);

        ScanFollowFire();
        if (!isPlayerDetected)
        {
            if (distance < 0.1f)
            {
                SetNewTargetPosition();
            }
            SetLookRotation(targetPosition);
            GotoTarget(targetPosition);
        }
    }

    private void ScanFollowFire()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 dir = (player.transform.position - transform.position).normalized;
        Debug.DrawRay(transform.position + new Vector3(0, 2, 0), dir * 2, Color.white);
        float angle = Vector3.Angle(dir, transform.forward);
        Debug.DrawRay(transform.position + new Vector3(0, 2, 0), transform.forward * maxCheckDistance, Color.blue);
        if (angle < FieldOfView)
        {
            Ray ray = new Ray(transform.position, dir * maxCheckDistance);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxCheckDistance))
            {
                Debug.DrawRay(transform.position, dir * maxCheckDistance, Color.green);
                string name = hitInfo.transform.name;
                Debug.Log(name + " Detected");
                isPlayerDetected = true;
                SetLookRotation(player.transform.position);
                if (distance < fireDistance)
                {
                    if ((delayed += Time.deltaTime) > 1f - fireSpeed)
                    {
                        Fire();
                        delayed = 0f;
                    }
                   
                }
                else
                {
                    GotoTarget(player.transform.position);
                }
            }
            else
                isPlayerDetected = false;
        }
    }
    private void Fire()
    {
        var bomb = Instantiate(bombPrefab, bombSpawnP.position, Quaternion.identity);
        bomb.AddForce(transform.forward * bombSpeed);
        Destroy(bomb, 2);
    }
    private void SetLookRotation(Vector3 targetPosition)
    {
        Vector3 dir = targetPosition - transform.position;
        dir.Normalize();
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    private void GotoTarget(Vector3 targetPosition)
    {
        if (Vector3.Distance(targetPosition, transform.position) < 0.1f) return;
        Vector3 dir = targetPosition - transform.position;
        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void SetNewTargetPosition()
    {
        if (looping)
        {
            if (index == path.Length - 1)
            {
                index = -1;
            }
        }
        if (index < path.Length - 1)
            index++;
        targetPosition = path.getPoint(index);
    }
}
