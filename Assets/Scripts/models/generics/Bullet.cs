using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    protected Rigidbody2D rigidbody2;

    void Start()
    {
        Destroy(gameObject, 2f);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Encostou!");
        Destroy(gameObject);
    }
}
