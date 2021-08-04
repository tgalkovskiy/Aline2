using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerNamaspase
{
    sealed class MovmentControler : MonoBehaviour
    {
        [SerializeField] private bool _joystic;
        [Header("Speed Player")][Tooltip("Speed Player")][SerializeField] [Range(1f, 10)] private float _speed = default;
        private float _x;
        private float _z;
        private void Update()
        {
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                 _x = Mathf.Clamp(Input.GetAxis("Horizontal"), -0.9f, 0.9f);
                 _z = Mathf.Clamp(Input.GetAxis("Vertical"), -0.9f, 0.9f);
                 transform.localPosition += AplyNewVector(ref _x, ref _z,ref _speed);
            }
            //transform.LookAt(, Input.mousePosition); //Quaternion.Euler(new Vector3(0, Input.mousePosition.y*Time.deltaTime, 0));
        }
        private Vector3 AplyNewVector(ref float x, ref float z, ref float speed)
        {
            return new Vector3(speed*Time.deltaTime*x, 0, speed*Time.deltaTime*z);
        }
    }
}

