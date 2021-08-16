
    using System;
    using UnityEngine;

    namespace Presenter
    {
        public class PresenterPlayer
        {
            public PresenterPlayer(View view, int hpPlayer)
            {
                _view = view;
                _modelPlayer = new ModelPlayer(hpPlayer);
                _modelPlayer._hpPlayerAction += _view.SetDamagePlayer;
            }

            private View _view;
            private ModelPlayer _modelPlayer;

            public void GetDamage_P(int damage)
            {
                _modelPlayer.m_GetDamage(damage);
            }
        }

        public class PresenterEnemy
        {
            public PresenterEnemy(View view, ConfigurationEnemy configurationEnemy, CollisionDetected collisionDetected)
            {
                _view = view;
                _modelEnemy = new ModelEnemy(configurationEnemy,collisionDetected);
                _modelEnemy._hpEnemyAction += _view.SetDamagePlayer;
                _modelEnemy._Die += _view.RemovePresenter_and_Model;
            }

            private View _view;
            private ModelEnemy _modelEnemy;

            public void SetHPEnemy(int hp)
            {
                _modelEnemy.m_SetHP(hp);
            }

            public void GetDamageEnemy(int damage)
            {
                _modelEnemy.m_GetDamage(damage);
            }
        }  
    }
    
    
    
    
    
