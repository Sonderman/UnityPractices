using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("bomb"))
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
