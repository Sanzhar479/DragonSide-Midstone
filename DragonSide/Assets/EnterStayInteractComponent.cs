using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnterStayInteractComponent : MonoBehaviour
{

    [SerializeField] private string _tag;
    [SerializeField] private LayerMask _layer = ~0;
    [SerializeField] private EnterEvent _action;

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (!other.gameObject.IsInLayer(_layer)) return;
        if (!string.IsNullOrEmpty(_tag) && !other.gameObject.CompareTag(_tag)) return;
        if (Input.GetKey(KeyCode.E)) { _action?.Invoke(other.gameObject);  Debug.Log("interacted"); }
        
    }
}
[Serializable]
public class InteractEvent : UnityEvent<GameObject>
{
}
