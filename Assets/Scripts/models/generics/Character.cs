using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
// public class Character : ICharacter using using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    public int life;
    public Rigidbody2D rgdb;
    protected bool isAlive;
    protected int nonStandingTime { get; private set; }
    public Stance stance = new Stance();
    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    protected float rotation;
    protected Vector2 position;



    public void Die()
    {
        life = 0;
        isAlive = false;
    }

    public void GetHit(int damage)
    {
        if (life > damage)
        {
            life = -damage;
        }
        else
        {
            Die();
        }
    }

    public float GetLife()
    {
        return life;
    }

    public Vector2 GetPosition()
    {
        return rgdb.position;
    }

    public float GetRotation()
    {
        return rgdb.rotation;
    }

    public bool isDead()
    {
        return isAlive;
    }

    public void MeleeAttack()
    {
        // TODO
    }

    public void Move(Vector2 position)
    {
        var transform_right = position.y > 0 ? transform.right : Utils.invertVector3(transform.right);
        rgdb.MovePosition(transform.position + transform_right * Time.fixedDeltaTime);
        ChangeStance(PlayerStances.walking);
    }

    public void RecoverLife(int recovered)
    {
        life += recovered;
    }

    public void Rotate(float rotationValue)
    {
        float extra_rotation = rotationValue > 0 ? 5 : -5;
        rotation = Utils.limitRotation(rotation + rotationValue + extra_rotation);
        rgdb.rotation = rotation;
    }

    public void ChangeStance(PlayerStances newStance)
    {
        stance.changeStance(newStance);
        spriteRenderer.sprite = stance.currentSprite;
        nonStandingTime = 0;
    }
}