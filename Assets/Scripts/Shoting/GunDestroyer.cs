using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject _effect = default;

    [SerializeField] private GameObject _bulletBody = default;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        _effect.SetActive(true);
        Destroy(_bulletBody);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        
    }
}
