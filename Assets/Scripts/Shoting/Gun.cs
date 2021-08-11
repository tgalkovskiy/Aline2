using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase;
using UnityEngine;

public class Gun : MonoBehaviour
{
   [SerializeField]
   private List<ConfigurationGun> guns = new List<ConfigurationGun>();
      
   private TypeGun typeGun;
   private Vector3 spawnPointBullet;
   private GameObject bulletPrefab;
   private float damage;
   private int bullets;
   private float shotDelay;
   private float reloadTime;
   private float velocityImpulse;
   private float weaponSpreed;


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

   private void OnShoot(bool isShoot)
   {
      if (isShoot)
      {
         Instantiate(bulletPrefab, spawnPointBullet, Quaternion.identity);
      }
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
