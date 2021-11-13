using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject prefab;
    [ContextMenu("Spawn")]
    public void Spawn()
    {
        var instance = Object.Instantiate(prefab, target.position, target.rotation);

        var scale = target.lossyScale;
        instance.transform.localScale = scale;
        instance.SetActive(true);
    }

    public void SetPrefab(GameObject prefab_)
    {
        prefab = prefab_;
    }
}
