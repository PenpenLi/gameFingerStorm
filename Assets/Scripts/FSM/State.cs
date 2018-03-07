using UnityEngine;
using System.Collections;

public class State<entity_type>
{
    public entity_type Target;

    //Enter State
    public virtual void Enter ( entity_type entityType )
    { 
        
    }

    //Execute State
    public virtual void Execute ( entity_type entityType )
    { 
        
    }

    //Exit State
    public virtual void Exit ( entity_type entityType )
    { 
        
    }

    public virtual bool OnMessage (entity_type entityType, Telegram telegram)
    {
        return false;
    }

}
