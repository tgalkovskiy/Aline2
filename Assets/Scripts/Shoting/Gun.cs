using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase;
using Presenter;
using UnityEngine;
using Random = UnityEngine.Random;


public class Gun : MonoBehaviour
{
    [SerializeField] private List<ConfigurationGun> gunsConfig = new List<ConfigurationGun>();
    [SerializeField] private List<GameObject> guns = new List<GameObject>();
    [SerializeField] private Transform _posSpawn;
    private Transform _bulletSpawn;
    private bool _bulletActive;
    private AnimationControler _animationController;

    public TypeGun typeGun;
    private GameObject bulletPrefab;
    private int damageGun;
    public int speedBullet;
    public int countBullet;

    private MovmentControler movmentControler;
    private View _view;
    private Vector3 _velosity = Vector3.forward;
    private void OnEnable()
    {
        movmentControler.ShootEvent += OnShoot;
        movmentControler.ChangeGun += ChangeWeapon;
    }

    private void OnDisable()
    {
        movmentControler.ShootEvent -= OnShoot;
        movmentControler.ChangeGun -= ChangeWeapon;
    }

    private void Awake()
    {
        _animationController = transform.GetChild(0).GetComponent<AnimationControler>();
        movmentControler = GetComponent<MovmentControler>();
        _view = View._Instance;
        Debug.Log(View._Instance);
    }

    private void Start()
    {
        SetNewConfigurationGun(gunsConfig[0]);
    }
    private void OnShoot(bool isShoot = true)
    {
        if (!isShoot)
        {
            _bulletSpawn?.gameObject.SetActive(false);
            _bulletActive = false;
            return;
        }
        if (_view.Shot(typeGun))
        {
            if (typeGun == TypeGun.FlamethrowerGun) {
                _bulletSpawn.gameObject.SetActive(true);
                _bulletSpawn.GetComponent<GunDestroyer>().damage = damageGun;
                _bulletActive = true;
                StartCoroutine(EContiniousShoot());
                return;
            }
            _animationController.ShotAnimation();
            for (int i = 0; i < countBullet; i++)
            {
                StartCoroutine(EShootBullet(typeGun == TypeGun.MachineGun ? .2f * i : 0));
            }
        }
    }
    public void ChangeWeapon(TypeGun gun)
    {
        for (int i = 0; i < gunsConfig.Count; i++)
        {
            guns[i].SetActive(false);
            if (gunsConfig[i].typeGun == gun)
            {
                SetNewConfigurationGun(gunsConfig[i]);
                guns[i].SetActive(true);
                _bulletSpawn = guns[i].transform.GetChild(0);
                _posSpawn = _bulletSpawn.transform;
            }
        }
        _view.ChangeGun(typeGun);
    }

    private void SetNewConfigurationGun(ConfigurationGun configurationGun)
    {
        typeGun = configurationGun.typeGun;
        bulletPrefab = configurationGun.bulletPrefab;
        damageGun = configurationGun.damage;
        speedBullet = configurationGun.speedBullet;
        countBullet = configurationGun.countBullet;
    }

    IEnumerator EShootBullet(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        var _bullet = Instantiate(bulletPrefab, _posSpawn.position, transform.rotation);
        _bullet.GetComponent<GunDestroyer>().damage = damageGun;
        switch (typeGun)
        {
            case TypeGun.Rifle:
            case TypeGun.MachineGun:
                _velosity = Vector3.forward; break;
            case TypeGun.ShotGun: _velosity = new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.1f, 0.1f), Random.Range(0.9f, 1.1f)); break;
        }
        _bullet.GetComponent<Rigidbody>().AddRelativeForce(_velosity * speedBullet, ForceMode.Acceleration);
    }

    IEnumerator EContiniousShoot()
    {
        yield return new WaitForSeconds(.5f);
        if (_bulletActive)
        {
            _view.Shot(typeGun);
            StartCoroutine(EContiniousShoot());
        }
    }
}