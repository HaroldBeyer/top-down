using UnityEngine;
using OB = Object;

public class CollectableBox : OB
{
    [SerializeField]

    public new void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Destroy();
                break;
        }
    }
}