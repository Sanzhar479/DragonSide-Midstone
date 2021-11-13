using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorChange : MonoBehaviour
{
    [SerializeField] private FightController player;

  

    private void Update()
    {
        if (player.HasSlashToken == true)
        {
            GetComponent<Image>().color = new Color32(52, 255, 0, 255);
        }
        else GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }
}
