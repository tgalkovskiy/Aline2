using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    public void CreateBullet(Vector3 posSpawn)
    {
       var Bullet= Instantiate(_bullet, posSpawn, Quaternion.identity);
    }
}
