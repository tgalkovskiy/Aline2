using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Configuration Enemy", order = 0)]
public class ConfigurationEnemy : ScriptableObject
{
    public float health;
    public float speed;
    public float damage;
    public float attackDelay;
}