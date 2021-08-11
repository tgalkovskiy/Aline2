using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Configuration Gun", order = 0)]

public class ConfigurationGun : ScriptableObject
{
    public TypeGun typeGun;
    public Vector3 spawnPointBullet;
    public GameObject bulletPrefab;
    public float damage;
    public int bullets;
    public float shotDelay;
    public float reloadTime;
    public float velocityImpulse;
    public float weaponSpreed;
}
