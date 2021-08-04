using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public TypeCollision _Type;
    public event Action<TypeCollision, TypeCollision> isCollision;
    private void OnCollisionEnter(Collision other)
    {
        isCollision.Invoke(_Type,other.collider.GetComponent<CollisionDetected>()._Type);
    }
}
