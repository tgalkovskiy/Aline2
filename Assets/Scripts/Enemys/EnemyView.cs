using System;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace PlayerNamaspase.Enemys
{
    public class EnemyView : MonoBehaviour
    {
        [HideInInspector] public CollisionDetected _player;
        [HideInInspector] public ConfigurationEnemy enemyConfig;
        [SerializeField] private Renderer _renderer;
        public TypeEnemy _Enemy;
        public ConfigurationEnemy[] enemyConfigAll;
        private EnemyState _state = EnemyState.Idle;
        private NavMeshAgent _agent;
        private Animator _animator;
       
        [Range(0.3f, 2.5f)]
        public float AttackSpeed = .5f;
        
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            SetParametrsEnemy();
        }

        private void SetParametrsEnemy()
        {
            switch (_Enemy)
            {
                case TypeEnemy.Default:
                    enemyConfig = enemyConfigAll[(int) TypeEnemy.Default];
                    break;
                case TypeEnemy.UpHp:
                    enemyConfig = enemyConfigAll[(int) TypeEnemy.UpHp];
                     _renderer.material = enemyConfig.material;
                    break;
                case TypeEnemy.UpDamage:
                    enemyConfig = enemyConfigAll[(int) TypeEnemy.UpDamage];
                    _renderer.material = enemyConfig.material;
                    break;
                case TypeEnemy.UpAll:
                    enemyConfig = enemyConfigAll[(int) TypeEnemy.UpAll];
                    _renderer.material = enemyConfig.material;
                    break;
            }
            transform.localScale = new Vector3(enemyConfig.scale, enemyConfig.scale, enemyConfig.scale);
            _agent.speed = enemyConfig.speed;
        }
        public void Move()
        {
            _state = EnemyState.Run;
            InvokeRepeating("Run", 0, 3);
            _animator.enabled = true;
            _animator.SetTrigger("Walk_Cycle_1");
        }
        public void Attack()
        {
            _state = EnemyState.Attack;
            _animator.SetTrigger(GetAttackAnimation());
            StartCoroutine(EAttack());
        }

        public void Run()
        {
            _agent.SetDestination(_player.transform.position);
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