using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PlayerNamaspase
{
    sealed class MovmentControler : MonoBehaviour
    {
        [SerializeField] private bool _joystic;
        [Header("Speed Player")][Tooltip("Speed Player")][SerializeField] [Range(1f, 7)] private float _speedWalk = default;
        [Header("Speed Player")][Tooltip("Speed Player")][SerializeField] [Range(8f, 15)] private float _speedRun = default;
        [Header("Camera sensitivity")][Tooltip("Camera sensitivity")][SerializeField] [Range(1f, 5)] private float _sensitivityCamera = default;
        private AnimationControler _animationControler;
        private float _x;
        private float _z;
        private float mouseX;
        private void Start()
        {
            _animationControler=transform.GetChild(0).GetComponent<AnimationControler>();
        }

        private void Update()
        {
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                 _x = Input.GetAxis("Horizontal");
                 _z = Input.GetAxis("Vertical");
                 if (Input.GetKey(KeyCode.LeftShift))
                 {
                     transform.Translate(AplyNewVector(ref _x, ref _z,ref _speedRun));
                     _animationControler.SetSpeed_and_strafe(_z*1.8f, _x);
                 }
                 else
                 {
                     transform.Translate(AplyNewVector(ref _x, ref _z,ref _speedWalk));
                     _animationControler.SetSpeed_and_strafe(_z, _x);
                 }
            }
            else
            {
                _animationControler.SetSpeed_and_strafe(0,0);

            }
            mouseX = Input.GetAxis("Mouse X");
            transform.rotation *= new Quaternion(0,mouseX*Time.deltaTime*_sensitivityCamera,0,1);

        }
        private Vector3 AplyNewVector(ref float x, ref float z, ref float speed)
        {
            return new Vector3(speed*Time.deltaTime*x, 0, speed*Time.deltaTime*z);
        }
    }
}

