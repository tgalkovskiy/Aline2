using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase.Enemys;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public TypeCollision _Type;
    public event Action<int> _getDamagePlayer;
    public event Action<int> _getDamageEnemy;
    public event Action<int> _getHpPlayer;
    public event Action _enemyAttack;
    public event Action _enemyMove;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<CollisionDetected>())
        {
            TypeCollision _collisionType = other.gameObject.GetComponent<CollisionDetected>()._Type;
            if (_Type == TypeCollision.Player && _collisionType == TypeCollision.Enemy)
            {
                _getDamagePlayer?.Invoke(other.gameObject.GetComponent<EnemyView>().enemyConfig.damage);
            }
            if (_Type == TypeCollision.Enemy && _collisionType == TypeCollision.Player)
            {
                _enemyAttack?.Invoke();
            }
            if (_Type == TypeCollision.Enemy && _collisionType == TypeCollision.Bullet)
            {
                _getDamageEnemy?.Invoke(other.gameObject.GetComponent<GunDestroyer>().damage);
            }
            if (_Type == TypeCollision.Player && _collisionType == TypeCollision.HpBox)
            {
                _getHpPlayer?.Invoke(25);
                Destroy(other.gameObject);
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<CollisionDetected>())
        {
            TypeCollision _collisionType = other.gameObject.GetComponent<CollisionDetected>()._Type;
            if (_Type == TypeCollision.Enemy && _collisionType == TypeCollision.Player)
            {
                _enemyMove?.Invoke();
            }
        }
    }
}
