using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    public float RotationSpeed = 240f;
    public Rigidbody BombPrefab;
    public float MoveSpeed = 5f;
    [Range(2000f, 10000f)]
    public float BombSpeed = 2000f;
    public Transform BombSpawnPoint;

    private void Update()
    {
        float moveAxis = Input.GetAxis("Vertical");
        float rotAxis = Input.GetAxis("Horizontal");
        transform.position += transform.forward * moveAxis * MoveSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(transform.up * rotAxis * RotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }
    private void Fire()
    {
        var Bomb = Instantiate(BombPrefab, BombSpawnPoint.position, Quaternion.identity);
        Bomb.AddForce(transform.forward* BombSpeed);
        Destroy(Bomb, 2);
    }
}
