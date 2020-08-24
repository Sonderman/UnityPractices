using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    int health = 100;
    public Text Htext;
    public void hit()
    {
        health -= 10;
        if (health == 0)
        {
            health = 100;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        Htext.text = health.ToString();
    }
}
