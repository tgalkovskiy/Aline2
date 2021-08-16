
    using System;
    using UnityEngine;

    public class ModelPlayer
    {
        public ModelPlayer(int hp)
        {
            _hpPlayer = hp;
        }
        public Action<int> _hpPlayerAction;
        public Action _hpPlayerDie;
        private int _hpPlayer;
        public void m_GetDamage(int damage)
        {
            _hpPlayer -= damage;
            if (_hpPlayer <= 0)
            {
                _hpPlayerDie.Invoke();
            }
            _hpPlayerAction.Invoke(_hpPlayer-damage);
        }
        
    }
    
    public class ModelEnemy
    {
        public ModelEnemy(ConfigurationEnemy configurationEnemy, CollisionDetected collisionDetected)
        {
            _health = configurationEnemy.health;
            _collisionDetected = collisionDetected;
        }
        private float _health;
        private CollisionDetected _collisionDetected;
        private ConfigurationEnemy _configurationEnemy;
        public Action<int> _hpEnemyAction;
        public Action<CollisionDetected> _Die;
        public Action<CollisionDetected> _Blood;
        public void m_GetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _Die.Invoke(_collisionDetected);
            }
            //_hpEnemyAction.Invoke(damage);
        }
        public void m_SetHP(int hp)
        {
            //_health -= hp;
           //_Die.Invoke(_collisionDetected);
        }
        public void m_SpawnBlood()
        {
            _Blood.Invoke(_collisionDetected);
        }
    }
    
