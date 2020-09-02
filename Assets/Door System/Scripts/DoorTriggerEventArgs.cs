using System;


public class DoorTriggerEventArgs : EventArgs
{
   public  int  id { get; private set; }
    public DateTime dateTime { get; private set; }
    public DoorTriggerEventArgs(int id)
    {
        this.id = id;
        dateTime = DateTime.Now;
    }
}
