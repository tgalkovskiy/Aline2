
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

            public void GetDamage_P(TypeCollision _first, TypeCollision _second)
            {
                if (_first != _second)
                {
                   _modelPlayer.m_GetDamage(10); 
                }
            }
        }

        public class PresenterEnemy
        {
            public PresenterEnemy(View view, ConfigurationEnemy configurationEnemy)
            {
                _view = view;
                _modelEnemy = new ModelEnemy(configurationEnemy);
                _modelEnemy._hpEnemyAction += _view.SetDamagePlayer;
            }

            private View _view;
            private ModelEnemy _modelEnemy;

            public void IsCollision(TypeCollision _first, TypeCollision _second)
            {
                if (_first != _second)
                {
                    _modelEnemy.m_GetDamage(10); 
                }
            }
            
        }  
    }
    
    
    
    
    
