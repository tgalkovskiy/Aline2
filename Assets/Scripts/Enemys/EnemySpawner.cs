using System;
using System.Collections;
using System.Collections.Generic;
using Presenter;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<CollisionDetected> _enemy = new List<CollisionDetected>();
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
}
