using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int botNumber;
    public GameObject botPrefab;

    void Start()
    {
        for (int i = 0; i < botNumber; i++)
        {
            Vector3 ranPosition = new Vector3(Random.Range(10f, -10f), 0, Random.Range(10f, -10f));
            Instantiate(botPrefab, ranPosition, botPrefab.transform.rotation) ;
        }
    }
}
