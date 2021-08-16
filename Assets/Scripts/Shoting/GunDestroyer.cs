using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _effect = default;
    [SerializeField] private GameObject _decal = default;
    [SerializeField] private GameObject _bulletBody = default;
    [SerializeField] private Transform _pos = default;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        StartCoroutine(Destroy(other.transform.eulerAngles));
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
