using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rb = default;
    [SerializeField] private Collider[] _capsuleColliders = default; 
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = true;
        
        foreach (var I in _rb)
        {
            I.isKinematic = false;
        }
        foreach (var I in _capsuleColliders)
        {
            I.enabled = false;
        }
    }
    public void SetSpeed_and_strafe(float speed, float strafe)
    {
        _animator.SetFloat("Speed", speed);
        _animator.SetFloat("Strafe", strafe);
    }

    public void ShotAnimation()
    {
        _animator.SetTrigger("IsShot");
    }

    public void Die()
    {
        _animator.enabled = false;
        foreach (var I in _rb)
        {
            I.isKinematic = true;
        }
        foreach (var I in _capsuleColliders)
        {
            I.enabled = true;
        }
    }

}
