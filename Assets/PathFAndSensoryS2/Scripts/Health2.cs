using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health2 : MonoBehaviour
{
    int health = 100;
    public Text Htext;
    public Transform camTransform;
    public Transform ui;
    public Image healthBar;

    private void Update()
    {
        ui.LookAt(camTransform,Vector3.up);
        ui.rotation = camTransform.rotation;
    }

    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            StartCoroutine(TakeDamageSmoothly(amount));
        }
    }

    private IEnumerator TakeDamageSmoothly(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            health--;
            if (health == 0)
            {
                health = 100;
            }
            Htext.text = health.ToString();
            healthBar.fillAmount = health / 100f;
            yield return null;
        }
    }
}
