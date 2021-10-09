using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtMouse : MonoBehaviour
{
    private GameObject parent;
    private void Start()
    {
        parent = GetComponentInParent<Transform>().gameObject;
    }
    void Update()
    {
     
        if (parent.gameObject.transform.localScale.x == -1)
        { gameObject.transform.localScale = new Vector3(1, 1, 1); }
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
