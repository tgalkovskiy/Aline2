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
        private Animator _animator;
        private bool isMove = false;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
        public void Move()
        {
            isMove = true;
            _animator.SetTrigger("Walk_Cycle_1");
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