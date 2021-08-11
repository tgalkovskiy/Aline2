using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour
{
    protected float health;
    protected float speed;
    protected float damage;
    protected float attackDelay;

    protected Rigidbody rb;
    protected abstract void Attack();
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    protected void SetConfigurationEnemy(ConfigurationEnemy enemy)
    {
        health = enemy.health;
        speed = enemy.speed;
        damage = enemy.damage;
        attackDelay = enemy.attackDelay;
    }

    protected void ChangeHealth(float value)
    {
        health -= value;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void Movement(Vector3 direction)
    {
        rb.MovePosition(transform.position+(direction.normalized*speed));
    }
}
