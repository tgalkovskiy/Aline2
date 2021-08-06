using System;
using System.Collections;
using System.Collections.Generic;
using Presenter;
using UnityEngine;
[ExecuteInEditMode]
public class CreateManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy =default;
    public Vector3 _posEnemy = default;
    [Space]
    [SerializeField] private GameObject _trap =default;
    public Vector3 _posTrap = default;

    private View _view;

    private void Start()
    {
        _view = View._Instance;
    }

    public void CreateEnemy(Vector3 positionSpawn)
    {
       var inst= Instantiate(_enemy, positionSpawn, Quaternion.identity);
       _view.AddPresenter_and_Model(inst.GetComponent<CollisionDetected>());
    }
    
    public void CreateTrap(Vector3 positionSpawn)
    {
        Instantiate(_trap, positionSpawn, Quaternion.identity);
    }
}
