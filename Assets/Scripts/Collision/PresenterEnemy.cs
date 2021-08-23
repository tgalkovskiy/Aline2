
    using System;
    using UnityEngine;

    namespace Presenter
    {
    public class PresenterPlayer
    {
        public PresenterPlayer(View view, ConfigurationPlayer configurationPlayer)
        {
            _view = view;
            _modelPlayer = new ModelPlayer(configurationPlayer);
            _modelPlayer._hpPlayerAction += _view.UpdatePlayerHP;
            _modelPlayer._hpPlayerDie += _view.DiePlayer;
            _modelPlayer._Blood += _view.SpawnBloodPlayer;
            _modelPlayer._ShotAction += _view.UpdateAmmo;
        }

        private View _view;
        private ModelPlayer _modelPlayer;

        public void GetDamage_P(int damage)
        {
            _modelPlayer.m_GetDamage(damage);
        }
        public bool Shot()
        {
            return _modelPlayer.Shot();
        }
        public void GetHP_P(int hp)
        {
            _modelPlayer.m_GetHp(hp);
        }
    }
    public class PresenterEnemy
        {
            public PresenterEnemy(View view, ConfigurationEnemy configurationEnemy, CollisionDetected collisionDetected)
            {
                _view = view;
                _modelEnemy = new ModelEnemy(configurationEnemy,collisionDetected);
                _modelEnemy._hpEnemyAction += _view.UpdatePlayerHP;
                _modelEnemy._Blood += _view.SpawnBloodSpaun;
                _modelEnemy._Die += _view.RemovePresenter_and_Model;
            }

            private View _view;
            private ModelEnemy _modelEnemy;

            /*public void SetHPEnemy(int hp)
            {
                _modelEnemy.m_SetHP(hp);
            }*/
            public void GetDamageEnemy(int damage)
            {
                _modelEnemy.m_GetDamage(damage);
            }
        }  
    }
    
    
    
    
    
