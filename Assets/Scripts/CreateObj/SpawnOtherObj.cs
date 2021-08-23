using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnOtherObj : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabDecal = new List<GameObject>();

    public void SpawnBlood(Transform pos)
    {
        Instantiate(_prefabDecal[Random.Range(0, _prefabDecal.Count)], pos.position, quaternion.Euler(0,Random.Range(0,180),0));
    }
}
