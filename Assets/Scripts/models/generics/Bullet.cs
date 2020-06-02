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
        // GameObject effect;
        // switch (collision.gameObject.tag)
        // {
        //     case "Enemy":
        //         effect = Instantiate(bloodEffect, transform.position, Quaternion.identity);
        //         Destroy(effect, 0.3f);
        //         break;
        //     default:
        //         effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //         Destroy(effect, 1f);
        //         break;
        // }

        Destroy(gameObject);
    }
}
