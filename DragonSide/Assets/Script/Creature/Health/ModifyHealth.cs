using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHealth : MonoBehaviour
{
    [SerializeField] private int hpDelta;

    public void Apply(GameObject target)
    {
        var healthComponent = target.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.ModifyHealth(hpDelta);
            Debug.Log(healthComponent);
        }
    }
}
