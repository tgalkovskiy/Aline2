using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnOtherObj : MonoBehaviour
{
    [SerializeField] private Transform Parent = default;
    [SerializeField] private List<GameObject> _prefabDecalSpaun = new List<GameObject>();
    [SerializeField] private List<GameObject> _prefabBloodExp = new List<GameObject>(); 
    [SerializeField] private List<GameObject> _prefabDecalPlayer = new List<GameObject>();
    private List<GameObject> _visualPool = new List<GameObject>();
    
    public void SpawnBloodSpaun(Transform pos)
    {
        
        _visualPool.Add(Instantiate(_prefabDecalSpaun[Random.Range(0, _prefabDecalSpaun.Count)], pos.position, quaternion.Euler(0,Random.Range(0,180),0), Parent)); 
        _visualPool.Add(Instantiate(_prefabBloodExp[Random.Range(0, _prefabBloodExp.Count)], pos.position, Quaternion.identity,  Parent));
        if (_visualPool.Count > 100)
        {
            int count = _visualPool.Count - 100;
            for (int i = 0; i < count; i++)
            {
                Destroy(_visualPool[0].gameObject);
                _visualPool.RemoveAt(0);
            }
        }
    }
    public void SpawnBloodPlayer(Transform pos)
    {
        //Instantiate(_prefabDecalPlayer[Random.Range(0, _prefabDecalPlayer.Count)], pos.position, quaternion.Euler(0,Random.Range(0,180),0));
    }
}
