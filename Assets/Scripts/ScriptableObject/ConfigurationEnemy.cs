using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Configuration Enemy", order = 0)]
public class ConfigurationEnemy : ScriptableObject
{
    public int health;
    public int speed;
    public int damage;
    public int attackDelay;
}