using UnityEngine;

public class Bomb : MonoBehaviour
{
   
    void Start()
    {
        Destroy(gameObject, 2);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="Bot"|| other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Health>().hit();
            Destroy(gameObject);
        }
        
    }
}
