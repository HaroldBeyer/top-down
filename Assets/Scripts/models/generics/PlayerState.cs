public class PlayerState : IState
{
    /**
    Actual state
    */
    public PlayerStates state { get; private set; }
    public int remainingTime { get; private set; }
    public int shootingCount { get; private set; }

    public PlayerState()
    {
        this.SetState(PlayerStates.roaming);
    }

    public void CheckTime()
    {
        if (this.remainingTime == 0 && this.state != PlayerStates.roaming)
        {
            SetState(PlayerStates.roaming);
        }
        else
        {
            this.remainingTime--;
        }
    }
    public void CheckShooting()
    {
        shootingCount--;
    }

    public void SetState()
    {
        throw new System.NotImplementedException();
    }

    public void SetState(PlayerStates state)
    {
        this.state = state;
        setRemaining(state);
    }

    protected void setRemaining(PlayerStates state)
    {
        switch (state)
        {
            case PlayerStates.healing:
                this.remainingTime = 80;
                break;
            case PlayerStates.reloading:
                this.remainingTime = 150;
                break;
            case PlayerStates.shooting:
                this.shootingCount = 8;
                break;
        }
    }
}