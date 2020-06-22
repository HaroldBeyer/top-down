public class EnemyState : IState<EnemyStates>
{
    public EnemyStates states { get; private set; }

    private int roamingTime = 1200;

    private int searchedPlayers;

    private int searchedPlayersAux;

    // EnemyS

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
            setRemaining();
    }

    private void setRemaining()
    {
        this.roamingTime = 100;
    }

    public EnemyState(int searchedPlayers)
    {
        this.SetState(EnemyStates.roaming);
        this.searchedPlayersAux = searchedPlayers;
    }

}