using UnityEngine;

public class AiTank : MonoBehaviour
{
    public Path path;
    public GameObject PlayerTank;
    Vector3 PointPosition;
    int PointIndex;
    public float MoveSpeed = 4f;
    public bool Looping;
    float Delayed=0f;
    public float FieldOfView = 60;
    public float FireDistance = 5f;
    public float maxCheckDistance = 15;
    [Range(0.1f, 0.8f)]
    public float FireSpeed = 0.5f;
    public Rigidbody BombPrefab;
    public Transform BombSpawnPoint;
    bool isPlayerDetected = false;
    [Range(2000f, 10000f)]
    public float BombSpeed = 2000f;
    public Transform Radar;
    public float RadarRotationSpeed = 50f;

    void Start()
    {
        PointPosition = path.getPoint(PointIndex);
    }


    void Update()
    {
        if (!isPlayerDetected)
        {
            Radar.Rotate(Vector3.forward* RadarRotationSpeed * Time.deltaTime);
        }
        

        float distance = Vector3.Distance(PointPosition, transform.position);

        RadarSensor();
        if (!isPlayerDetected)
        {
            if (distance < 0.1f)
            {
                SetNewPathPosition();
            }
            SetLookRotation(PointPosition);
            GoTarget(PointPosition);
        }
    }

    private void RadarSensor()
    {
        float distance = Vector3.Distance(PlayerTank.transform.position, Radar.position);
        Vector3 direction = (PlayerTank.transform.position - Radar.position).normalized;
        Debug.DrawRay(Radar.position + new Vector3(0, 2, 0), direction * 3, Color.white);
        float angle = Vector3.Angle(direction, Radar.up);
        Debug.DrawRay(Radar.position + new Vector3(0, 1, 0), Radar.up * maxCheckDistance, Color.blue);
        if (angle < FieldOfView)
        {
            Ray ray = new Ray(Radar.position, direction * maxCheckDistance);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxCheckDistance))
            {
                Debug.DrawRay(Radar.position, direction * maxCheckDistance, Color.green);
                string name = hitInfo.transform.name;
                Debug.Log(name + " Detected");
                isPlayerDetected = true;
                SetLookRotation(PlayerTank.transform.position);
                if (distance < FireDistance)
                {
                    if ((Delayed += Time.deltaTime) > 1f - FireSpeed)
                    {
                        Fire();
                        Delayed = 0f;
                    }
                   
                }
                else
                {
                    GoTarget(PlayerTank.transform.position);
                }
            }
            else
                isPlayerDetected = false;
        }
    }
    private void Fire()
    {
        var bomb = Instantiate(BombPrefab, BombSpawnPoint.position, Quaternion.identity);
        bomb.AddForce(transform.forward * BombSpeed);
        Destroy(bomb, 2);
    }
    private void SetLookRotation(Vector3 targetPosition)
    {
        Vector3 dir = targetPosition - transform.position;
        dir.Normalize();
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    private void GoTarget(Vector3 targetPosition)
    {
        if (Vector3.Distance(targetPosition, transform.position) < 0.1f) return;
        Vector3 dir = targetPosition - transform.position;
        dir.Normalize();
        transform.position += dir * MoveSpeed * Time.deltaTime;
    }

    private void SetNewPathPosition()
    {
        if (Looping)
        {
            if (PointIndex == path.Length - 1)
            {
                PointIndex = -1;
            }
        }
        if (PointIndex < path.Length - 1)
            PointIndex++;
        PointPosition = path.getPoint(PointIndex);
    }
}
