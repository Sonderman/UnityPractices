using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5f;
    float rotSpeed = 240f;

    void Update()
    {
        float moveAxis = Input.GetAxis("Vertical");
        float rotAxis = Input.GetAxis("Horizontal");
        transform.position += transform.forward * moveAxis * moveSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(transform.up * rotAxis*rotSpeed* Time.deltaTime); 
    }
}
