using UnityEngine;

public class Bomb2 : MonoBehaviour
{
   
    void Start()
    {
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter(Collider otherTank)
    {
        if(otherTank.gameObject.name =="AiTank"|| otherTank.gameObject.name == "PlayerTank")
        {
            otherTank.gameObject.GetComponent<Health2>().TakeDamage(10);
            Destroy(gameObject);
        }
        
    }
}
