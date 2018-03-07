using UnityEngine;


public class BaseGameEntity : MonoBehaviour
{
    public virtual bool HandleMessage ( Telegram telegram )
    {
        return false;
    }
}
