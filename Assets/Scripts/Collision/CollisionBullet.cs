using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    public GameObject _bullet;

    private void OnCollisionEnter(Collision collision)
    {
        var _collision = collision.gameObject.GetComponent<CollisionDetected>();
        if (_collision !=null || _collision._Type == TypeCollision.enemy)
        { 
            PlayAndStopSound.PlaySomeSoundEnemy();
            Destroy(_bullet);
            Debug.Log("Shoot");
        }
    }
}
