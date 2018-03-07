using UnityEngine;


public class StateMachine<entity_type>
{
    private entity_type m_pOwner;

    private State<entity_type> m_pCurrentState;
    private State<entity_type> m_pPreviousState;
    private State<entity_type> m_pGlobalState;

    public StateMachine ( entity_type owner )
    {
        this.m_pOwner = owner;
        this.m_pCurrentState = null;
        this.m_pPreviousState = null;
        this.m_pGlobalState = null;
    }

    public void GlobalStateEnter ()
    {
        this.m_pGlobalState.Enter(this.m_pOwner);
    }
    
    public void SetGlobalState ( State<entity_type> GlobalState )
    {
        this.m_pGlobalState = GlobalState;
        this.m_pGlobalState.Target = this.m_pOwner;
        this.m_pGlobalState.Enter(this.m_pOwner);  
    }

    public void SetCurrentState ( State<entity_type> CurrentState )
    {
        this.m_pCurrentState = CurrentState;
        this.m_pCurrentState.Target = this.m_pOwner;
        this.m_pCurrentState.Enter(this.m_pOwner);
    }

    public void SMUpdate ()
    {
        if (this.m_pGlobalState != null)
            this.m_pGlobalState.Execute(this.m_pOwner);

        if (this.m_pCurrentState != null)
            this.m_pCurrentState.Execute(this.m_pOwner);
    }

    public void ChangeState ( State<entity_type> pNewState )
    {
        if (pNewState == null)
        {
            Debug.LogError("State is null!");
        }

        this.m_pCurrentState.Exit(this.m_pOwner);
        this.m_pPreviousState = this.m_pCurrentState;

        this.m_pCurrentState = pNewState;
        this.m_pCurrentState.Target = this.m_pOwner;
		this.m_pCurrentState.Enter(this.m_pOwner);
    }

    public void RevertToPreviousState ()
    {
        ChangeState(this.m_pPreviousState);
    }

    public State<entity_type> CurrentState ()
    {
        return this.m_pCurrentState;
    }

    public State<entity_type> GlobalState ()
    {
        return this.m_pGlobalState;
    }

    public State<entity_type> PreviousState ()
    {
        return this.m_pPreviousState;
    }

    public bool HandleMessage ( Telegram msg )
    {
        if (this.m_pCurrentState != null && this.m_pCurrentState.OnMessage(this.m_pOwner, msg))
        {
            return true;
        }

        if (this.m_pGlobalState != null && this.m_pGlobalState.OnMessage(this.m_pOwner, msg))
        {
            return true;
        }

        return false;
    }

}

