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
    public bool hedgehog = false;
    public bool vampirism = false;

    [TextArea]public string[] _description; 
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

    public void SetHedgehog()
    {
        hedgehog = true;
    }

    public void SetVampirism()
    {
        vampirism = true;
    }
    public void SetDefault()
    {
        health = 100;
        ammo = 50;
        damage = 15;
        hedgehog = false;
        vampirism = false;
    }
}
