using System;
using System.Collections;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace PlayerNamaspase.Enemys
{
    public class EnemyView : MonoBehaviour
    {
        [HideInInspector] public CollisionDetected _player;
        public ConfigurationEnemy enemyConfig;
        private EnemyState _state = EnemyState.Idle;
        private NavMeshAgent _agent;
        private Animator _animator;
        [Range(0.3f, 2.5f)]
        public float AttackSpeed = .5f;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
        public void Move()
        {
            _state = EnemyState.Run;
            _animator.SetTrigger("Walk_Cycle_1");
        }
        public void Attack()
        {
            _state = EnemyState.Attack;
            _animator.SetTrigger(GetAttackAnimation());
            StartCoroutine(EAttack());
        }

        public void Die()
        {
            _animator.SetTrigger("Die");
            StartCoroutine(EDie());
        }
        private void FixedUpdate()
        {
            if (_state == EnemyState.Run)
            {
                _agent.SetDestination(_player.transform.position);
            }
        }
        private string GetAttackAnimation()
        {
            int AttackNumber = 5;
            return "Attack_" + Random.Range(1, AttackNumber + 1);
        }

        IEnumerator EDie()
        {
            _agent.Stop();
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
        IEnumerator EAttack()
        {
            yield return new WaitForSeconds(AttackSpeed);
            if (_state != EnemyState.Attack)
            {
                StopCoroutine(EAttack());
            }
            else
            {
                Attack();
            }
        }
    }
}