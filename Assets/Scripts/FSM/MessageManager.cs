using UnityEngine;


public class MessageManager : MonoBehaviour
{
    private MessageDispatcher messageDispatcher;

    void Start ()
    {
        this.messageDispatcher = MessageDispatcher.Instance();
    }

    void Update ()
    {
        this.messageDispatcher.DispatchDelayedMessage();
    }
}

