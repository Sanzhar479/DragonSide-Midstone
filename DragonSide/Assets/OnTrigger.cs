using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private OnOverlapEvent OnTriggerEnterGO;
    [SerializeField] private UnityEvent OnTriggerEnter;
    [SerializeField] protected LayerMask layer;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnTriggerEnterGO != null)
        {
            OnTriggerEnterGO?.Invoke(collision.gameObject);
            return;
        }
        if (OnTriggerEnter != null)
        {
            OnTriggerEnter?.Invoke();
            return;
        }
    }
    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {

    }
}
