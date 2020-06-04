using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InActionHandler();

public class PlayerState : IState
{
    /**
    Actual state
    */
    public PlayerStates state { get; private set; }
    public int remainingTime { get; private set; }
    public int shootingCount { get; private set; }
    private Player player;
    public List<Gun> gunList;
    public event InActionHandler InAction;

    public PlayerState(Player player, List<Gun> gunList)
    {
        this.player = player;
        this.gunList = gunList;
        this.SetState(PlayerStates.roaming);
    }

    public void CheckTime()
    {
        if (this.state == PlayerStates.reloading && this.remainingTime > 0)
        {
            player.ChangeStance(PlayerStances.reloading);
        }
        if ((this.shootingCount <= 0 || !gunList[player.gunNumber].HasAmmo()) && this.state == PlayerStates.shooting)
        {
            player.CancelShooting();
            SetState(PlayerStates.roaming);
        }
        else if (this.remainingTime <= 0 && this.state != PlayerStates.roaming)
        {
            player.ChangeStance(PlayerStances.standing);
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