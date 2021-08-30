using System;
using System.Collections;
using System.Collections.Generic;
using PlayerNamaspase;
using PlayerNamaspase.Enemys;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Presenter
{
    public class View : MonoBehaviour
    {
        public ConfigurationPlayer _configurationPlayer = default;
       [SerializeField] private CollisionDetected _player = default;
       [SerializeField] private UiHolder _uiHolder = default;
       [SerializeField] private SpawnOtherObj spawnOtherObj = default;
       [SerializeField] private Animator _playerAnimator = default;
       private List<CollisionDetected> _enemy = new List<CollisionDetected>();
       private PresenterPlayer _presenterPlayer;
       private List<PresenterEnemy> _presenters = new List<PresenterEnemy>();
       private bool isExecute = false;
       public GameObject DestroyerExecute; 
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
           _presenterPlayer = new PresenterPlayer(this, _configurationPlayer);
           _player._ShowAction += _presenterPlayer.DOShowShowAction;
           _player._getDamagePlayer += _presenterPlayer.GetDamage_P;
           _player._DataAction += _presenterPlayer.GetDataAction;
           
           _uiHolder._hpSlider.maxValue = _configurationPlayer.health;
           _uiHolder._hpSlider.value = _configurationPlayer.health;
           
           _uiHolder._armor.maxValue = _configurationPlayer.armor;
           _uiHolder._armor.value = _configurationPlayer.armor;
           
           //_uiHolder._experience.maxValue = _configurationPlayer.exp;
           _uiHolder._experience.value = _configurationPlayer.exp;
           
           _uiHolder._nowHp.text = _configurationPlayer.health.ToString();
           //_uiHolder._ammo.text = _configurationPlayer.rifleAmmo.ToString();
           _uiHolder._armorText.text = _configurationPlayer.armor.ToString();
           _uiHolder._experienceNowText.text = _configurationPlayer.exp.ToString();
       }
       public bool Shot(TypeGun typeGun)
       {
           return _presenterPlayer.Shot(typeGun);
       }
       public void ShowAction(bool isShow)
       {
           _uiHolder._ActionText.SetActive(isShow);
           isExecute = isShow;
       }
       public void ChangeGun(TypeGun typeGun)
       {
           _presenterPlayer.ChangeGun(typeGun);
       }
       public void ExecuteAction()
       {
           if (isExecute)
           {
              _presenterPlayer.ExecuteAction();
              _uiHolder._ActionText.SetActive(false);
              Destroy(DestroyerExecute);
           }
       }
       public void UpdatePlayerHP(int nowhp)
       {
           _uiHolder._hpSlider.value = nowhp;
           _uiHolder._nowHp.text = nowhp.ToString();
       }
       public void UpdatePlayerArmor(int nowArmor)
       {
           _uiHolder._armor.value = nowArmor;
           _uiHolder._armorText.text = nowArmor.ToString();
       }
       public void UpdateAmmo(int nowAmmo)
       {
           _uiHolder._ammo.text = nowAmmo.ToString();
       }
       public void UpdateExp(int nowExp)
       {
           _uiHolder._experience.value = nowExp;
           _uiHolder._experienceNowText.text = nowExp.ToString();
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
           _enemy[_enemy.Count - 1]._getDamageEnemy += _presenters[_presenters.Count - 1].GetDamageEnemy;
           _enemy[_enemy.Count - 1]._enemyAttack += _view.Attack;
           _enemy[_enemy.Count - 1]._enemyMove += _view.Move;
       }
       public void SpawnBloodSpaun(CollisionDetected _collisionDetected)
       {
           spawnOtherObj.SpawnBloodSpaun(_collisionDetected.transform);
       }
       public void SpawnBloodPlayer()
       {
           spawnOtherObj.SpawnBloodPlayer(_player.transform);
       }

       public void GetExp(int exp)
       {
           _presenterPlayer.GetExp(exp);
       }
       public void RemovePresenter_and_Model(CollisionDetected _collisionDetected)
       {
           _enemy.RemoveAt(_enemy.FindIndex(x => x.name ==_collisionDetected.name));
           GetExp(_collisionDetected.gameObject.GetComponent<EnemyView>().enemyConfig.exp);
           Destroy(_collisionDetected.gameObject);
           _presenterPlayer.ExucuteVampirism();
       }
       
   } 
}

