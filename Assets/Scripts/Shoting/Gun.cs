using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase;
using Presenter;
using UnityEngine;
using Random = UnityEngine.Random;


public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject Granate;
    [SerializeField] private List<ConfigurationGun> gunsConfig = new List<ConfigurationGun>();
    [SerializeField] private List<GameObject> guns = new List<GameObject>();
    [SerializeField] private Transform _posSpawn;
    [SerializeField] private Transform _posSpawnGrenade;
    private AnimationControler _animationController;
    
    public TypeGun typeGun;
    private GameObject bulletPrefab;
    private int damageGun;
    private bool isShoot = true;
    private int speedBullet;
    private int countBullet;
    
    private MovmentControler movmentControler;
    private View _view;
    private Vector3 _velosity = Vector3.forward;
    private void OnEnable()
    {
        movmentControler.ShootEvent += OnShoot;
        movmentControler.ChangeGun += ChangeWeapon;
        movmentControler.GrenadeThrow += TrownGranete;
    }

    private void OnDisable()
    {
        movmentControler.ShootEvent -= OnShoot;
        movmentControler.ChangeGun -= ChangeWeapon;
        movmentControler.GrenadeThrow -= TrownGranete;
    }

    private void Awake()
    {
         _animationController=transform.GetChild(0).GetComponent<AnimationControler>();
        movmentControler = GetComponent<MovmentControler>();
        _view = View._Instance;
    }

    private void Start()
    {
        SetNewConfigurationGun(gunsConfig[0]);
    }
    
    private void OnShoot()
    {
        if(_view.Shot(typeGun))
        {
            _animationController.ShotAnimation();
            for (int i = 0; i < countBullet; i++)
            {
                var _bullet = Instantiate(bulletPrefab, _posSpawn.position, transform.rotation);
                _bullet.GetComponent<GunDestroyer>().damage =damageGun;
                switch (typeGun)
                {
                    case TypeGun.Rifle: _velosity = Vector3.forward; break;
                    case TypeGun.ShotGun: _velosity = new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.1f, 0.1f), Random.Range(0.8f, 1.2f)); break;
                }
                _bullet.GetComponent<Rigidbody>().AddRelativeForce(_velosity*speedBullet, ForceMode.Acceleration);
            }
        }
    }
    public void ChangeWeapon(TypeGun gun)
    {
        for(int i = 0; i < gunsConfig.Count; i++)
        {
            guns[i].SetActive(false);
            if (gunsConfig[i].typeGun == gun)
            {
                SetNewConfigurationGun(gunsConfig[i]);
                guns[i].SetActive(true);
                _posSpawn = guns[i].transform.GetChild(0).transform;
            }
        }
        _view.ChangeGun(typeGun);
    }

    private void TrownGranete()
    {
        var granete = Instantiate(Granate, _posSpawnGrenade.position, transform.rotation);
        granete.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*700, ForceMode.Acceleration);
    }
    private void SetNewConfigurationGun(ConfigurationGun configurationGun)
    {
        typeGun = configurationGun.typeGun;
        bulletPrefab = configurationGun.bulletPrefab;
        damageGun = configurationGun.damage;
        speedBullet = configurationGun.speedBullet;
        countBullet = configurationGun.countBullet;
    }

   
}