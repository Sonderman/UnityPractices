using UnityEngine;

public class BombShooter : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform spawn;
    

    float elapsedTime = 0;
    float delay = 0.5f;
    void Update()
    {
        if((elapsedTime += Time.deltaTime)> delay)
        {
            //var bomb=Instantiate(bombPrefab, spawn.position, bombPrefab.transform.rotation);
            
            var bomb = ObjectPooler.instance.getPooledObject();
            if (bomb != null)
            {
                bomb.transform.position = spawn.position;
                bomb.transform.rotation = spawn.rotation;
                bomb.SetActive(true);
                bomb.GetComponent<Rigidbody>().velocity = spawn.forward * 10f;
            }
            
        }
        
    }
}
