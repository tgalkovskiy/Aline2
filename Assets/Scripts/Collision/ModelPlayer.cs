
    using System;
    using UnityEngine;

    public class ModelPlayer
    {
        public ModelPlayer(int hp)
        {
            _hpPlayer = hp;
        }
        public Action<int> _hpPlayerAction;
        private int _hpPlayer;
        public void m_GetDamage(int damage)
        {
            _hpPlayer -= damage;
            _hpPlayerAction.Invoke(damage);
        }
    }
    
    public class ModelEnemy
    {
        public ModelEnemy(ConfigurationEnemy configurationEnemy)
        {
            _configurationEnemy = configurationEnemy;
        }
        private ConfigurationEnemy _configurationEnemy;
        public Action<int> _hpEnemyAction;
        public void m_GetDamage(int damage)
        {
            _hpEnemyAction.Invoke(damage);
        }
    }
    
