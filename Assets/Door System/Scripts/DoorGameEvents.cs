using System;
using UnityEngine;

public class DoorGameEvents : MonoBehaviour
{

    public static DoorGameEvents instance;
    
    void Awake()
    {
        instance = this;
    }


    public delegate void DoorTriggerEvent(object sender, EventArgs args);
    public event  DoorTriggerEvent onDoorTriggerEnter;
    public event DoorTriggerEvent onDoorTriggerExit;
    //public event Action<int> onDoorTriggerEnter;
    //public event Action<int> onDoorTriggerExit;

    public void DoorTriggerEnter(int id)
    {
        if(onDoorTriggerEnter != null)
        {
            DoorTriggerEventArgs args = new DoorTriggerEventArgs(id);   
            onDoorTriggerEnter(this,args);
        }
    }
    public void DoorTriggerExit(int id)
    {
        if(onDoorTriggerExit != null)
        {
            DoorTriggerEventArgs args = new DoorTriggerEventArgs(id);
            onDoorTriggerExit(this, args);
        }
    }

}
