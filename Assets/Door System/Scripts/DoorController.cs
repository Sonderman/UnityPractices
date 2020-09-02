using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool isRegistered = false;
    public int id;
    void Start()
    {
        if (isRegistered)
        {
            Register();
        }
    }
    private void OnDestroy()
    {
        UnRegister();
    }

    private void Register()
    {
        //abone olma işlemi
        DoorGameEvents.instance.onDoorTriggerEnter += onDoorTriggerEnter;
        DoorGameEvents.instance.onDoorTriggerExit += onDoorTriggerExit;
        isRegistered = true;
    }

    private void UnRegister()
    {
        //abonelikten çıkma işlemi
        DoorGameEvents.instance.onDoorTriggerEnter -= onDoorTriggerEnter;
        DoorGameEvents.instance.onDoorTriggerExit -= onDoorTriggerExit;
        isRegistered = false;
    }

    private void onDoorTriggerExit(object sender, EventArgs args)
    {
        DoorTriggerEventArgs doorArgs = (DoorTriggerEventArgs)args;
        if (this.id == doorArgs.id)
        {
            LeanTween.moveLocalY(gameObject, -0.658f, 1f).setEaseInOutQuad();
        }
        
        
    }

    private void onDoorTriggerEnter(object sender,EventArgs args)
    {
        DoorTriggerEventArgs doorArgs = (DoorTriggerEventArgs)args;
        if (this.id == doorArgs.id)
        {
            LeanTween.moveLocalY(gameObject, 1f, 1f).setEaseInOutQuad();
        }
        Debug.Log("at" + doorArgs.dateTime + "there is a invasion");
    }

    private void OnMouseDown()
    {
        
        if (isRegistered)
        {
            UnRegister();
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            Register();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }


}
