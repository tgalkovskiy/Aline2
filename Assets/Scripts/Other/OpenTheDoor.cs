
using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class OpenTheDoor : MonoBehaviour
{
   public bool isOpen;
   [SerializeField] private GameObject _door = default;
   [SerializeField] private Transform _targetPos = default;
   private Vector3 _defaultPos;
   
   private void Start()
   {
      _defaultPos = _door.transform.localPosition;
      if (isOpen)
      {
          GetComponent<BoxCollider>().isTrigger = true;
      }
      else
      {
         GetComponent<BoxCollider>().isTrigger = false;

      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if(isOpen)
      _door.transform.DOLocalMove(_targetPos.localPosition, 1f).OnComplete((() => StartCoroutine(CloseDoor())));
   }

   IEnumerator CloseDoor()
   {
      yield return new WaitForSeconds(2);
      _door.transform.DOLocalMove(_defaultPos, 1f);
   }
}
