using UnityEngine;
public class BotController : MonoBehaviour
{
    bool isRegistered = false;
    Vector3 targetPosition;
    GameEvents Event =GameEvents.instance;
    void Start()
    {
        targetPosition = transform.position;
        if (!isRegistered)
        {
            Register();
        }
    }

    private void Update()
    {
        if (targetPosition != transform.position)
        {
            float distance = Vector3.Distance(targetPosition, transform.position);
            if (distance < 0.1f) return;
            Vector3 dir = targetPosition - transform.position;
            dir.Normalize();
            transform.position += dir * 5 * Time.deltaTime;
        }
        
    }
    private void OnDestroy()
    {
        UnRegister();
    }

    private void Register()
    {
        Debug.Log("Abone Olundu");
        Event.onBotTriggerEnter += onBotTriggerEnter;
        Event.onBotTriggerExit += onBotTriggerExit;
        isRegistered = true;
    }
    private void UnRegister()
    {
        //abonelikten çıkma işlemi
        Event.onBotTriggerEnter -= onBotTriggerEnter;
        Event.onBotTriggerExit -= onBotTriggerExit;
        isRegistered = false;
    }
    private void onBotTriggerExit()
    {
        //targetPosition = transform.position;
    }

    private void onBotTriggerEnter(Transform Targettransform)
    {
        targetPosition = Targettransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Event.BotTriggerEnter(other.gameObject.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //Event.BotTriggerExit();
            targetPosition = transform.position;
        }
    }
}
