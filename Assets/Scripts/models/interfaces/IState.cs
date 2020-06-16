public interface IState<T>
{
    void SetState(T t);

    void CheckTime();


}