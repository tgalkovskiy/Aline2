using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Configuration Enemy", order = 0)]
public class ConfigurationEnemy : ScriptableObject
{
    public int health;
    public float speed;
    public int damage;
    public int attackDelay;
    public float scale;
    public Material material;
}