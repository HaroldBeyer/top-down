interface IObject
{
    void OnCollisionEnter2D(UnityEngine.Collision2D other);

    void OnHit(int damage);

    void Destroy();

}