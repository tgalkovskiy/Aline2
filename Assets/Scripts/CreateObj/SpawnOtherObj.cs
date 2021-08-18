using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnOtherObj : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabDecalSpaun = new List<GameObject>();
    [SerializeField] private List<GameObject> _prefabDecalPlayer = new List<GameObject>();

    public void SpawnBloodSpaun(Transform pos)
    {
        Instantiate(_prefabDecalSpaun[Random.Range(0, _prefabDecalSpaun.Count)], pos.position, quaternion.Euler(0,Random.Range(0,180),0));
    }
    public void SpawnBloodPlayer(Transform pos)
    {
        //Instantiate(_prefabDecalPlayer[Random.Range(0, _prefabDecalPlayer.Count)], pos.position, quaternion.Euler(0,Random.Range(0,180),0));
    }
}
