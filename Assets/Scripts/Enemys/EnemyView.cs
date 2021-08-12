using System;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace PlayerNamaspase.Enemys
{
    public class EnemyView : MonoBehaviour
    {
        [HideInInspector] public CollisionDetected _player;
        public ConfigurationEnemy enemyConfig;
        private NavMeshAgent _agent;
        private bool isMove = false;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        public void Move()
        {
            isMove = true;
        }
        private void FixedUpdate()
        {
            if (isMove)
            {
                _agent.SetDestination(_player.transform.position);
            }
        }
    }
}