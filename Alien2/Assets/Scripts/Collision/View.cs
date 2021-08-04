using System;
using System.Collections;
using System.Collections.Generic;
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
           _player.isCollision += _presenterPlayer.GetDamage_P;
           if (_enemy.Count > 0)
           {
               for (int i = 0; i < _enemy.Count; i++)
               {
                   _presenters.Add(new PresenterEnemy(this, 100*i));
                   _enemy[i].isCollision += _presenters[i].GetDamage_P;
               }
           }
       }
       
       public void SetDamagePlayer(int damage)
       {
           Debug.Log($"player get {damage} damage");
       }
       public void SetDamageEnemy(int damage)
       {
           Debug.Log($"enemy get {damage} hp");
       }
       
       public void AddPresenter_and_Model(CollisionDetected _collisionDetected)
       {
           _enemy.Add(_collisionDetected);
       }
       public void RemovePresenter_and_Model(CollisionDetected _collisionDetected, int indexCollider)
       {
            _enemy[indexCollider] = _enemy[_enemy.Count-1];
            _enemy.RemoveAt(_enemy.Count-1);
           
       }
       public void RemovePresenter_and_Model(CollisionDetected _collisionDetected, string nameCollider)
       {
           _enemy.RemoveAt(_enemy.FindIndex(x => x.name == nameCollider));
       }
   
   } 
}

