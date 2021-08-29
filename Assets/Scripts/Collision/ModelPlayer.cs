
    using System;
    using UnityEngine;

    public class ModelPlayer
    {
        public ModelPlayer(ConfigurationPlayer _configurationPlayer)
        {
            _hpPlayer = _configurationPlayer.health;
            _armor = _configurationPlayer.armor;
            _ammo = _configurationPlayer.ammo;
            configurationPlayer = _configurationPlayer;
            _hedgehog = _configurationPlayer.hedgehog;
            _vampirism = _configurationPlayer.vampirism;
            _timeStop = configurationPlayer.timeStop;
            _exp = configurationPlayer.exp;
        }
        private int _hpPlayer;
        private int _ammo;
        private int _armor;
        private int _exp;
        private bool _hedgehog = false;
        private bool _vampirism = false;
        private bool _timeStop = false;
        private bool isLife = true;
        public Action<int> _hpPlayerAction;
        public Action<int> _armorPlayerAction;
        public Action<int> _expAction;
        public Action<bool> _ActionShow;
        public Action<int> _ShotAction;
        
        public Action _hpPlayerDie;
        public Action _Blood;
        
        private TypeAction _typeAction;
        private int _value;
        
        private CollisionDetected _collisionDetected;
        private ConfigurationPlayer configurationPlayer;

        public void Load()
        {
            configurationPlayer.Load();
        }

        public void Save()
        {
            configurationPlayer.Save();
        }
        public void m_GetDamage(int damage)
        {
            if (isLife)
            {
                if (_armor > 0)
                {
                    _armor = Mathf.Clamp(_armor - damage, 0, configurationPlayer.armor);
                    _armorPlayerAction.Invoke(_armor);
                }
                else
                {
                    _hpPlayer -= damage;
                    if (_timeStop && _hpPlayer < configurationPlayer.health / 2)
                    {
                        Time.timeScale = 0.75f;
                    }
                    else
                    {
                        Time.timeScale = 1;
                    }
                    if (_hpPlayer <= 0)
                    {
                        _hpPlayerDie.Invoke();
                        isLife = false;
                    }
                    _hpPlayerAction.Invoke(_hpPlayer);
                }

                _Blood.Invoke();
            }
        }
        public bool Shot()
        {
             _ShotAction.Invoke(_ammo);
            if (_ammo > 0)
            {
                _ammo--;
                return true; 
            }
            else
            {
                return false;
            }
        }
        public void m_ShowAction(bool isShow)
        {
           _ActionShow?.Invoke(isShow);
        }
        public void m_GetDataAction(TypeAction typeAction, int value)
        {
            _typeAction = typeAction;
            _value = value;
        }
        public void m_ExecuteAction()
        {
            if (_typeAction == TypeAction.AddHealth)
            {
                _hpPlayer = Mathf.Clamp(_hpPlayer + _value, 0, configurationPlayer.health);
                _hpPlayerAction?.Invoke(_hpPlayer);
                
            }
            if (_typeAction == TypeAction.AddAmmo)
            {
                _ammo += _value;
                _ShotAction.Invoke(_ammo);
            }
        }
        public void m_ExecuteVampirism()
        {
            if (_vampirism)
            {
                _hpPlayer += 1;
                _hpPlayerAction.Invoke(_hpPlayer);
            }
        }
        public void m_GetExp(int exp)
        {
            _exp += exp;
            _expAction.Invoke(_exp);
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
            _Blood.Invoke(_collisionDetected);
        }
        
    }
    
