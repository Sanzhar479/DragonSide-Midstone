using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnVisionEnter : MonoBehaviour
{
    [SerializeField] private IEnumerator onEnterVision;
    [SerializeField] private float timeToDelay;
    [SerializeField] private Mob mob;
    [SerializeField] private PointPatrol patrol;
    private Animator anim;
    private float count = 0;
    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }
    //When you enter vision, it triggers notice animation after which enemy changes state
    //Also it resets the timer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("Notice");
        StopCoroutine(TimeDelayAfterExitVision());
        count = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        StopCoroutine(TimeDelayAfterExitVision());
        count = 0;
    }
    //When player exits the vision the timer starts, after which mob continue brousing or patroling
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(TimeDelayAfterExitVision());
        count = 0;
    }
    //timer you exit vision
    private IEnumerator TimeDelayAfterExitVision()
    {
        while (true)
        {
            Debug.Log(count);
            if (count >= timeToDelay)
            {
                mob.StartState(patrol.DoPatrol());
                break;
            }
            count++;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
