using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnVisionEnter : MonoBehaviour
{
    [SerializeField] private StateMachine1 sm1;
    [SerializeField] private StateMachine2 sm2;
    [SerializeField] private StateMachine3 sm3;
    public Transform player;
    //When you enter vision, it triggers notice animation after which enemy changes state
    //Also it resets the timer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sm1 != null)
        {
            sm1.SetState(1);
            sm1.playerTransform = collision.gameObject.transform;
        }
        else if (sm2 != null)
        {
            sm2.SetState(1);
            sm2.playerTransform = collision.gameObject.transform;
        }
        else { 
            sm3.SetState(1);
            sm3.playerTransform = collision.gameObject.transform;
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (sm1 != null)
    //        sm1.SetState(1);
    //    else if (sm2 != null)
    //        sm2.SetState(1);
    //    else sm3.SetState(1);
    //}
    //When player exits the vision the timer starts, after which mob continue brousing or patroling
}
