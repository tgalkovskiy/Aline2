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
    
    public void SetUpHp(bool boosted)
    {
        health = boosted ? 150 : 100;
    }

    public void SetUpAmmo(bool boosted)
    {
        ammo = boosted ? 150 : 100;
    }

    public void SetUpDamage(bool boosted)
    {
        damage = boosted ? 25 : 10;
    }
}
