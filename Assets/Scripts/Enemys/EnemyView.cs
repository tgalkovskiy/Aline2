using System;
using System.Collections;
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
        public EnemyState _state = EnemyState.Idle;
        private NavMeshAgent _agent;
        private Animator _animator;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
        public void Move()
        {
            _state = EnemyState.Run;
            _animator.enabled = true;
            _animator.SetTrigger("Walk_Cycle_1");
        }
        private void FixedUpdate()
        {
            if (_state == EnemyState.Run)
            {
                _agent.SetDestination(_player.transform.position);
            }

            //UpdateAnimator();
        }
        /*private void UpdateAnimator()
        {
            switch (_state)
            {
                case EnemyState.Walk:
                    _animator.SetTrigger("Armature|Walk_Cycle_2");
                    break;
                case EnemyState.Run:
                    _animator.SetTrigger("Armature|Walk_Cycle_2");
                    break;
                case EnemyState.Die:
                    _animator.SetTrigger("Die");
                    break;
                default:
                    _animator.SetTrigger("Armature|Rest_1");
                    break;
            }
        }*/
    }
}