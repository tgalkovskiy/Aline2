
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class OpenTheDoor : MonoBehaviour
{
   [SerializeField] private GameObject _door = default;
   [SerializeField] private Transform _targetPos = default;
   private Vector3 _defaultPos;

   private void Start()
   {
      _defaultPos = _door.transform.localPosition;
   }

   private void OnTriggerEnter(Collider other)
   {
      _door.transform.DOLocalMove(_targetPos.localPosition, 1f).OnComplete((() => StartCoroutine(CloseDoor())));
   }

   IEnumerator CloseDoor()
   {
      yield return new WaitForSeconds(2);
      _door.transform.DOLocalMove(_defaultPos, 1f);
   }
}
