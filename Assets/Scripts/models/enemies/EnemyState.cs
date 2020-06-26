using UnityEngine;

public class EnemyState : IState<EnemyStates>
{
    public EnemyStates states { get; private set; }

    private int roamingTime;

    private int searchedPlayers;

    private int searchedPlayersAux;
    public Vector2 position { get; private set; }


    public void CheckTime()
    {
        if (states == EnemyStates.roaming)
        {
            roamingTime--;
            if (roamingTime <= 0)
                SetState(EnemyStates.searching);
        }
        else
        {
            searchedPlayers--;
            if (searchedPlayers <= 0)
                SetState(EnemyStates.roaming);
        }
    }

    public void SetState(EnemyStates t)
    {
        this.states = t;
        if (t == EnemyStates.roaming)
        {
            setRemaining();
            setPosition();
        }
        else if (t == EnemyStates.searching)
        {
            setSearchingPlayers();
        }
    }

    private void setSearchingPlayers()
    {
        this.searchedPlayers = this.searchedPlayersAux;
    }

    private void setPosition()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);
        position = new Vector2(x, y);
    }

    private void setRemaining()
    {
        this.roamingTime = 400;
    }

    public EnemyState(int searchedPlayers)
    {
        this.SetState(EnemyStates.roaming);
        this.searchedPlayersAux = searchedPlayers;
    }

}