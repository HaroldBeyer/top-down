using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public interface ICharacter
{
    void Move(Vector2 position);
    float GetLife();
    Vector2 GetPosition();
    float GetRotation();
    void Die();
    void MeleeAttack();
    void GetHit(float damage);
    void RecoverLife(int recovered);
    void Rotate(float rotationValue);
    bool isDead();
    void ChangeStance(PlayerStances newStance);


}