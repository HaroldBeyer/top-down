using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
// public class Character : ICharacter using using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    public float life;
    public Rigidbody2D rgdb;
    protected bool isAlive;
    protected int nonStandingTime { get; private set; }
    public Stance stance = new Stance();
    [SerializeField]
    protected SpriteRenderer spriteRenderer;
    protected float rotation;
    protected Vector2 position;
    [SerializeField]
    protected GameObject healthBar;
    protected HealthState healthState = new HealthState();



    public void Die()
    {
        life = 0;
        isAlive = false;
        print("You are dead");
    }

    public void GetHit(float damage)
    {
        if (life > damage)
        {
            life -= damage;
            HandleHealth();
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

    private void HandleHealth()
    {
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x, life / 100, healthBar.transform.localScale.y);
        healthState.SetState(true);
        healthBar.SetActive(true);
    }
}