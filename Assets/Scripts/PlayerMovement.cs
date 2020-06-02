using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 movement;

    public int playerNumber;

    private Rigidbody2D rigidbody2D;
    private Vector2 position;
    private SpriteRenderer spriteRenderer;
    private float rotation;
    public Sprite standingSprite;
    public Sprite walkingSprite;
    public Sprite firePistolSprite;
    public Sprite fireSilencedSprite;
    public Sprite fireMachineGunSprite;
    public Sprite reloadingSprite;
    private int nonStandingTime;

    public GameObject bulletObject;

    private string[] keyNames = new string[2];

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = rigidbody2D.position;
        rigidbody2D.rotation = 90;
        rotation = rigidbody2D.rotation;
        keyNames[0] = playerNumber == 0 ? "Horizontal" : "Horizontal" + playerNumber.ToString();
        keyNames[1] = playerNumber == 0 ? "Vertical" : "Vertical" + playerNumber.ToString();
    }
    private void LateUpdate()
    {
        Shoot();
        if (spriteRenderer.sprite != standingSprite)
        {
            nonStandingTime++;
            if (nonStandingTime > 25)
            {
                changeSprite(PlayerStances.standing);
            }
        }
    }
    private void FixedUpdate()
    {
        MoveFoward();

    }
    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 firePointPosition = transform.position;
            firePointPosition.x = +5;
            firePointPosition.y = +5;
            changeSprite(PlayerStances.fire_pistol);
        };
    }
    private void MoveFoward()
    {

        movement.x = -Input.GetAxis(keyNames[0]);
        movement.y = Input.GetAxis(keyNames[1]);

        if (movement.x != 0)
        {
            float extra_rotation = movement.x > 0 ? 5 : -5;
            rotation = rotation + movement.x + extra_rotation;
            limitRotation();
            rigidbody2D.rotation = rotation;
        }
        if (movement.y < 0)
        {
            rigidbody2D.MovePosition(transform.position + invertVector3(transform.right) * Time.fixedDeltaTime);
            changeSprite(PlayerStances.walking);
        }
        if (movement.y > 0)
        {
            rigidbody2D.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
            changeSprite(PlayerStances.walking);
        }
    }

    private Vector3 invertVector3(Vector3 vector3)
    {
        vector3.x = -vector3.x;
        vector3.y = -vector3.y;
        vector3.z = -vector3.z;
        return vector3;
    }

    private void limitRotation()
    {
        if (rotation > 360 || rotation < -360)
        {
            rotation = 0;
        }
    }

    private void changeSprite(PlayerStances stance)
    {
        stance.ToString();
        switch (stance)
        {
            case PlayerStances.standing:
                spriteRenderer.sprite = standingSprite;
                break;
            case PlayerStances.walking:
                spriteRenderer.sprite = walkingSprite;
                break;
            case PlayerStances.fire_pistol:
                spriteRenderer.sprite = firePistolSprite;
                break;
            case PlayerStances.fire_silenced:
                spriteRenderer.sprite = fireSilencedSprite;
                break;
            case PlayerStances.fire_machine:
                spriteRenderer.sprite = fireMachineGunSprite;
                break;
            case PlayerStances.reloading:
                spriteRenderer.sprite = reloadingSprite;
                break;
        }
        nonStandingTime = 0;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        print("Collision ended " + rigidbody2D.angularDrag);
        rigidbody2D.freezeRotation = true;
    }
}
