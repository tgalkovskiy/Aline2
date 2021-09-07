using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDestroyer : MonoBehaviour
{
    [HideInInspector]public int damage;
    [SerializeField] private GameObject _effect = default;
    [SerializeField] private GameObject _bulletBody = default;
    [SerializeField] private bool _destroy = true;
    private void OnCollisionEnter(Collision other)
    {
        if (_destroy)
        {
            StartCoroutine(Destroy(other.transform.eulerAngles));
        }
    }

    IEnumerator Destroy(Vector3 rot)
    {
        //var decol = Instantiate(_decal, _pos.position, Quaternion.Euler(0,_decal.transform.rotation.y+rot.y,-90));
        _effect.SetActive(true);
        Destroy(_bulletBody);
        yield return new WaitForSeconds(0.2f);
        //Destroy(decol.gameObject);
        Destroy(gameObject);
        
    }
}
