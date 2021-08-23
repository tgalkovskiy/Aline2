using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Configuration Player", order = 0)]
public class ConfigurationPlayer : ScriptableObject
{
    public int health;
    public float speed;
    public int damage;
    public float attackDelay;
    public int ammo;
    
    public void SetUpHp()
    {
        health = 150;
    }

    public void SetUpAmmo()
    {
        ammo = 150;
    }

    public void SetUpDamage()
    {
        damage = 25;
    }
}
