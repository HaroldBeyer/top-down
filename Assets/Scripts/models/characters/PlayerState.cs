using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InActionHandler();

public class PlayerState : IState<PlayerStates>
{
    /**
    Actual state
    */
    public PlayerStates state { get; private set; }
    public int remainingTime { get; private set; }
    private Player player;
    public event InActionHandler InAction;

    public PlayerState(Player player)
    {
        this.player = player;
        this.SetState(PlayerStates.roaming);
    }

    public void CheckTime()
    {
        if (this.state == PlayerStates.reloading && this.remainingTime > 0)
        {
            player.ChangeStance(PlayerStances.reloading);
        }
        else if (this.remainingTime <= 0 && this.state != PlayerStates.roaming)
        {
            player.ChangeStance(PlayerStances.standing);
            SetState(PlayerStates.roaming);
        }

        if (this.remainingTime > 0)
            this.remainingTime--;

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
        }
    }
}