using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuComponent : MonoBehaviour
{
    [SerializeField] private Canvas PlayerMenu;
    public bool GamePused;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (PlayerMenu.gameObject.activeSelf == false)
            { PlayerMenu.gameObject.SetActive(true); GamePused = true; }
            else { PlayerMenu.gameObject.SetActive(false); GamePused = false; }

        }

    }
}
