using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    public void DestroyObject()
    {
        Destroy(objectToDestroy);
    }
}
