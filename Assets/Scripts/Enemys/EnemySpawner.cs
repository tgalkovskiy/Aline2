using System.Collections;
using System.Collections.Generic;
using Presenter;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<CollisionDetected> _enemy = new List<CollisionDetected>();
    //public float _period;
    //float _nextSpawn;

    //public Vector3 _center;
    //public Vector3 _size;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject?.GetComponent<CollisionDetected>()._Type == TypeCollision.Player)
        {
            for (int i = 0; i < _enemy.Count; i++)
            {
               View._Instance.AddPresenter_and_Model(_enemy[i]); 
            }
            
        }
        Destroy(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.1f, 0.1f,0.4f);
        Gizmos.DrawCube(transform.position, new Vector3(5,5,5));
    }

    /*void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        Vector3 _pos = _center + new Vector3(Random.Range(-_size.x / 2, _size.x / 2), Random.Range(-_size.y / 2, _size.y / 2), Random.Range(-_size.z / 2, _size.z / 2));
        Instantiate(_enemy, _pos, Quaternion.identity); 
    }*/



    /*void Start()
    {
        _nextSpawn = Random.Range(0, _period);
    }
    void Update()
    {
        _nextSpawn -= Time.deltaTime;
        if (_nextSpawn <= 0.0f)
        {
            _nextSpawn = _period;
            Instantiate(_enemy, transform.position, Quaternion.identity);
        }
    }*/
}
