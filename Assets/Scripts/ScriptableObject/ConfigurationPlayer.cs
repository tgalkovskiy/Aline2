using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Configuration Player", order = 0)]
public class ConfigurationPlayer : ScriptableObject
{
    public float health;
    public float speed;
    public float damage;
    public float attackDelay;
    
    public void SetUpHp()
    {
        health = 150;
    }
}
