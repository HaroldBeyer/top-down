public class HealthState : IState<bool>
{
    public bool state { get; private set; } = false;
    private int remainingTime = 100;
    public void SetState(bool t)
    {
        state = t;
        setRemaining();
    }

    public void CheckTime()
    {
        if (remainingTime > 0)
        {
            remainingTime--;
        }
        else
        {
            SetState(false);
        }
    }

    private void setRemaining()
    {
        if (state)
        {
            remainingTime = 100;
        }
        else
        {
            remainingTime = 0;
        }
    }
}