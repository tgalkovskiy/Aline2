using System;
using System.Collections;
using System.Collections.Generic;
using Presenter;
using UnityEngine;

namespace PlayerNamaspase
{
    sealed class MovmentControler : MonoBehaviour
    {
        [SerializeField] private bool _joystic;
        [SerializeField] private Joystick _horizontal = default;
        [SerializeField] private Joystick _vertical = default;
        [Header("Speed Player")][Tooltip("Speed Player")][SerializeField] [Range(1f, 7)] private float _speedWalk = default;
        [Header("Speed Player")][Tooltip("Speed Player")][SerializeField] [Range(8f, 15)] private float _speedRun = default;
        [Header("Camera sensitivity")][Tooltip("Camera sensitivity")][SerializeField] [Range(1f, 5)] private float _sensitivityCamera = default;
        [SerializeField] private ShakeCameraControl _shakeCamera = default;
        private AnimationControler _animationController;
        private Rigidbody _rigidbody;
        private float _x;
        private float _z;
        private float mouseX;
        private bool run = false;
        public event Action ShootEvent;
        public event Action<TypeGun> ChangeGun;
        public event Action GrenadeThrow;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animationController=transform.GetChild(0).GetComponent<AnimationControler>();
        }

        private void Update()
        {
            if(_joystic)
            {
                _x = _horizontal.Horizontal;
                _z = _horizontal.Vertical;
                mouseX = _vertical.Horizontal;
                transform.rotation *= new Quaternion(0,mouseX*Time.deltaTime*_sensitivityCamera,0,1);
            }
            else
            {
                _x = Input.GetAxis("Horizontal");
                _z = Input.GetAxis("Vertical");
                mouseX = Input.GetAxis("Mouse X");
                transform.rotation *= new Quaternion(0,mouseX*Time.deltaTime*_sensitivityCamera,0,1);
            }
            if (Input.GetMouseButtonDown(0))
            {
                ShootEvent?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                GrenadeThrow?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                View._Instance.ExecuteAction();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeGun(TypeGun.Rifle);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeGun(TypeGun.ShotGun);
            }
        }
        private void FixedUpdate()
        {
            if(_x != 0 || _z != 0)
            {
                _rigidbody.AddRelativeForce(AplyNewVector(ref _x, ref _z, ref _speedWalk));
                _animationController.SetSpeed_and_strafe(_z, _x);
                _shakeCamera.SetShakeCamera(1.5f);
            }
            else
            {
                _animationController.SetSpeed_and_strafe(0,0);
                _shakeCamera.SetShakeCamera(0.75f);
            }
        }
        private Vector3 AplyNewVector(ref float x, ref float z, ref float speed)
        {
            return new Vector3(speed*Time.deltaTime*x*1000, 0, speed*Time.deltaTime*z*1000);
        }
        
    }
}

