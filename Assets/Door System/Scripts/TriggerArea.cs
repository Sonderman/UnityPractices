using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        DoorGameEvents.instance.DoorTriggerEnter(id);
    }
    private void OnTriggerExit(Collider other)
    {
        DoorGameEvents.instance.DoorTriggerExit(id);
    }
}
