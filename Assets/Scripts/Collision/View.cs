using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase;
using PlayerNamaspase.Enemys;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Presenter
{ 
    [ExecuteInEditMode]
   public class View : MonoBehaviour
   {
       [Header("All CollisionDetected")][SerializeField] private List<CollisionDetected> _enemy = new List<CollisionDetected>();
       [SerializeField] private CollisionDetected _player = default;
       [SerializeField] private UiPlayerStats _uiPlayerStats = default;
       [SerializeField] private SpawnOtherObj spawnOtherObj = default;
       [SerializeField] private Animator _playerAnimator = default;
       private PresenterPlayer _presenterPlayer;
       private List<PresenterEnemy> _presenters = new List<PresenterEnemy>();
       public static View _Instance;
       
       private void Awake()
       {
           if (_Instance == null)
           {
               _Instance = this;
           }
           else
           {
               Destroy(this);
           }
           _presenterPlayer = new PresenterPlayer(this, 100);
           _player._getDamagePlayer += _presenterPlayer.GetDamage_P;
           //_player.isCollision += _presenterPlayer.GetDamage_P;
       }
       public void UpdatePlayerHP(int nowhp)
       {
           _uiPlayerStats._hpSlider.value = nowhp;
       }
       public void DiePlayer()
       {
           _player.gameObject.GetComponent<MovmentControler>().enabled = false;
           _playerAnimator.SetTrigger("Die");
       }
       public void AddPresenter_and_Model(CollisionDetected _collisionDetected)
       {
           _enemy.Add(_collisionDetected);
           EnemyView _view = _collisionDetected.gameObject.GetComponent<EnemyView>();
           _view._player = _player;
           _view.Move();
           _presenters.Add(new PresenterEnemy(this, _view.enemyConfig, _collisionDetected));
           _enemy[_enemy.Count-1]._setHpEnemy+=_presenters[_presenters.Count-1].SetHPEnemy;
           _enemy[_enemy.Count - 1]._getDamageEnemy += _presenters[_presenters.Count - 1].GetDamageEnemy;
           _enemy[_enemy.Count - 1]._SpawnBlood += _presenters[_presenters.Count - 1].SpawBlood;
           _enemy[_enemy.Count - 1]._enemyAttack += _view.Attack;
           _enemy[_enemy.Count - 1]._enemyMove += _view.Move;
           _player._SpawnBlood += _presenterPlayer.SpawBlood;
       }
       public void RemovePresenter_and_Model(CollisionDetected _collisionDetected, int indexCollider)
       {
            _enemy[indexCollider] = _enemy[_enemy.Count-1];
            _enemy.RemoveAt(_enemy.Count-1);
           
       }
       public void SpawnBloodSpaun(CollisionDetected _collisionDetected)
       {
           spawnOtherObj.SpawnBloodSpaun(_collisionDetected.transform);
       }
       public void SpawnBloodPlayer()
       {
           spawnOtherObj.SpawnBloodPlayer(_player.transform);
       }
       public void RemovePresenter_and_Model(CollisionDetected _collisionDetected)
       {
           //_collisionDetected.gameObject.GetComponent<EnemyView>().Die();
           _enemy.RemoveAt(_enemy.FindIndex(x => x.name ==_collisionDetected.name));
           Destroy(_collisionDetected.gameObject);
       }
       
   } 
}

