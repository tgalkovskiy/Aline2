using System;
using UnityEngine;

namespace PlayerNamaspase.Enemys
{
    public class EnemyCrab : Enemy
    {
        [SerializeField] ConfigurationEnemy enemyConfig;
        [SerializeField] private GameObject[] points;
        private void Start()
        {
            SetConfigurationEnemy(enemyConfig);
        }

        private void FixedUpdate()
        {
            Movement(points[0].transform.position);
        }

        protected override void Attack()
        {
           
        }
    }
}