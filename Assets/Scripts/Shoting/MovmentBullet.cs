using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentBullet : MonoBehaviour
{
   [SerializeField] private AnimationCurve _acceleration;
   [SerializeField] private float _speed = 10f;
   private float time = 0;
   private float _nowSpeed;

   private void Start()
   {
      _nowSpeed = _speed;
   }

   private void Update()
   {
      time += Time.deltaTime;
      _nowSpeed = _speed - _acceleration.Evaluate(time) * time / 2;
      Debug.Log(_nowSpeed);
   }
}
