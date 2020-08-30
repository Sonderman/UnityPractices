using System;
using UnityEngine;
public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    private void Awake()
    {
        instance = this;
    }

    //public delegate void BotTriggerEvent<Transform>(object obj);
    public event  Action<Transform> onBotTriggerEnter;
    public event Action onBotTriggerExit;

    public void BotTriggerEnter(Transform transform)
    {
        onBotTriggerEnter?.Invoke(transform);
    }
    public void BotTriggerExit()
    {
        onBotTriggerExit?.Invoke();
    }
}
