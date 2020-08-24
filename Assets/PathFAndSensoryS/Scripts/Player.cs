using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotSpeed = 240f;
    public Rigidbody bombPrefab;
    public Transform bombSpawnP;
    [Range(2000f, 10000f)]
    public float bombSpeed = 2000f;
    

    private void Update()
    {
        float moveAxis = Input.GetAxis("Vertical");
        float rotAxis = Input.GetAxis("Horizontal");
        transform.position += transform.forward * moveAxis * moveSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(transform.up * rotAxis * rotSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }
    private void Fire()
    {
        var bomb = Instantiate(bombPrefab, bombSpawnP.position, Quaternion.identity);
        bomb.AddForce(transform.forward* bombSpeed);
        Destroy(bomb, 2);
    }
}
