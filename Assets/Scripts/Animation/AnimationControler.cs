using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
    

}
