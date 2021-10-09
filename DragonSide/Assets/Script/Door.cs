using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool IsInTrigger = false;
    [SerializeField] private int sceneNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsInTrigger = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            IsInTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            IsInTrigger = false;
    }
    private void Transfer()
    {
        if (Input.GetKey(KeyCode.E) && IsInTrigger == true)
            SceneManager.LoadScene(sceneNum);
    }
    private void Update()
    {
        Transfer();
    }
}
