using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer = default;
    [SerializeField] private GameObject _explosion = default;
    [SerializeField] private GameObject _explosionCircle = default;
    [SerializeField] private GameObject ligth = default;
    [SerializeField] private GameObject[] raound = default;
    private void Start()
    {
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3);
        ligth.SetActive(true);
        for(int i= 0; i<raound.Length; i++)
        {
            raound[i].SetActive(true);
        }
        renderer.enabled = false;
        _explosion.SetActive(true);
        _explosionCircle.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ligth.SetActive(false);
        for (int i = 0; i < raound.Length; i++)
        {
            raound[i].SetActive(false);
        }
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
