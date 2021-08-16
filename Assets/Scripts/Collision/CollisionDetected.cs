using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public TypeCollision _Type;
    
    public event Action<int> _getDamagePlayer;
    public event Action<int> _getDamageEnemy;
    public event Action<int> _setHpEnemy; 
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<CollisionDetected>())
        {
            TypeCollision _collisionType = other.gameObject.GetComponent<CollisionDetected>()._Type;
            if (_Type == TypeCollision.Player && _collisionType == TypeCollision.Enemy)
            {
                _getDamagePlayer.Invoke(10);
            }
            if (_Type == TypeCollision.Enemy && _collisionType == TypeCollision.Player)
            {
                _setHpEnemy.Invoke(10);
            }

            if (_Type == TypeCollision.Enemy && _collisionType == TypeCollision.Bullet)
            {
                _getDamageEnemy.Invoke(50);
                Debug.Log(1);
            }
        }
    }
}
