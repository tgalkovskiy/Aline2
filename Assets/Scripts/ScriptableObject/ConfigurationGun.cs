using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Configuration Gun", order = 0)]
public class ConfigurationGun : ScriptableObject
{
    public TypeGun typeGun;
    public GameObject bulletPrefab;
    public int damage;
    public int speedBullet;
    public int countBullet;

}
