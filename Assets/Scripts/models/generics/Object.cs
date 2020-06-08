using UnityEngine;


public class Object : MonoBehaviour, IObject
{
    [SerializeField]
    private ObjectStance stance;
    [SerializeField]
    private int health;
    [SerializeField]
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    private Collider2D collider2;



    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.collider2 = GetComponent<Collider2D>();
        spriteRenderer.sprite = stance.changeStance(ObjectStances.normal);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        print("Hit!");
        print(other.gameObject.tag);

        switch (other.gameObject.tag)
        {
            case "PistolBullet":
                OnHit(2);
                break;
            case "SilencedPistolBullet":
                OnHit(3);
                break;
            case "MachineGunBullet":
                OnHit(1);
                break;
        }
        //PistolAmmo, SilencedPistolAmmo, MachineGunAmmo
    }

    public void OnHit(int damage)
    {
        print("On hit! " + damage);
        if (damage >= health)
        {
            this.health = 0;
            Destroy();
            return;
        }
        else if ((health - damage) < health / 2)
        {
            spriteRenderer.sprite = stance.changeStance(ObjectStances.damaged);
        }
        this.health--;
    }

    public void Destroy()
    {
        spriteRenderer.sprite = stance.changeStance(ObjectStances.destroyed);
        this.collider2.enabled = false;
    }



}