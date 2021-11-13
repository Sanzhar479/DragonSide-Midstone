using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class OnCollision : MonoBehaviour
{
    [SerializeField] private OnOverlapEvent OnCollisionEnterGO;
    [SerializeField] private UnityEvent OnCollisionEnter;
    [SerializeField] protected LayerMask layer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnCollisionEnterGO != null) {
            OnCollisionEnterGO?.Invoke(collision.gameObject);
            return;
        }
        if (OnCollisionEnter != null)
        {
            OnCollisionEnter?.Invoke();
            return;
        }
    }
    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {

    }
}
