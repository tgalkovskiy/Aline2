using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private List<ConfigurationGun> guns = new List<ConfigurationGun>();
    [SerializeField] private Transform _posSpawn;
    private TypeGun typeGun;
    private Vector3 spawnPointBullet;
    private GameObject bulletPrefab;
    private float damage;
    private int bullets;
    private float shotDelay;
    private float reloadTime;
    private float velocityImpulse;
    private float weaponSpreed;
    private bool isShoot;
    private float timer;
    private MovmentControler movmentControler;

    private void OnEnable()
    {
        movmentControler.ShootEvent += OnShoot;
    }

    private void OnDisable()
    {
        movmentControler.ShootEvent -= OnShoot;
    }

    private void Awake()
    {
        movmentControler = GetComponent<MovmentControler>();
    }

    private void Start()
    {
        SetNewConfigurationGun(guns[0]);
    }
    private void OnShoot()
    {
        var _bullet = Instantiate(bulletPrefab, _posSpawn.position, transform.rotation);
        _bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*3000, ForceMode.Acceleration);
    }

    public void ChangeWeapon(TypeGun gun)
    {
        foreach (var i in guns)
        {
            if (i.typeGun == gun)
            {
                SetNewConfigurationGun(i);
                break;
            }
        }
    }

    private void SetNewConfigurationGun(ConfigurationGun configurationGun)
    {
        typeGun = configurationGun.typeGun;
        bulletPrefab = configurationGun.bulletPrefab;
        damage = configurationGun.damage;
        bullets = configurationGun.bullets;
        shotDelay = configurationGun.shotDelay;
        reloadTime = configurationGun.reloadTime;
        velocityImpulse = configurationGun.velocityImpulse;
        weaponSpreed = configurationGun.weaponSpreed;
        spawnPointBullet = configurationGun.spawnPointBullet;
    }
}