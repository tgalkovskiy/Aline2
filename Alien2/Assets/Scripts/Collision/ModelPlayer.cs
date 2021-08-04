
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
        public ModelEnemy(int hp)
        {
            _hpEnemy = hp;
        }
        public Action<int> _hpEnemyAction;
        private int _hpEnemy;
        public void m_GetDamage(int damage)
        {
            _hpEnemy += damage;
            _hpEnemyAction.Invoke(damage);
        }
    }
    
