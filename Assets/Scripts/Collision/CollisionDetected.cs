using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase.Enemys;
using Presenter;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public TypeCollision _Type;
    public event Action<int> _getDamagePlayer;
    public event Action<int> _getDamageEnemy;
    public event Action<bool> _ShowAction;
    public event Action<TypeAction, int> _DataAction;
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
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<CollisionDetected>())
        {
            TypeCollision _collisionType = other.gameObject.GetComponent<CollisionDetected>()._Type;
            if (_Type == TypeCollision.Player && _collisionType == TypeCollision.Action)
            {
                var obj = other.gameObject.GetComponent<ActionObj>();
                _ShowAction?.Invoke(true);
                _DataAction?.Invoke(obj._TypeAction, obj.value);
                View._Instance.DestroyerExecute =other.gameObject;
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
            if (_Type == TypeCollision.Player && _collisionType == TypeCollision.Action)
            {
                _ShowAction?.Invoke(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<CollisionDetected>())
        {
            TypeCollision _collisionType = other.gameObject.GetComponent<CollisionDetected>()._Type;
            if (_Type == TypeCollision.Player && _collisionType == TypeCollision.Trap)
            {
                _getDamagePlayer?.Invoke(other.gameObject.GetComponent<TrapView>()._ConfigTrap._damage);
            }
            if (_Type == TypeCollision.Enemy && _collisionType == TypeCollision.Trap)
            {
                _getDamageEnemy?.Invoke(other.gameObject.GetComponent<TrapView>()._ConfigTrap._damage);
            }
        }
    }
}
