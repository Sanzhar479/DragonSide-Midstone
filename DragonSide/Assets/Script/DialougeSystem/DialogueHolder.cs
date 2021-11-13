using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : DialogueBaseClass
    {
        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }
        private IEnumerator dialogueSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Diactivate();
              
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(()=> transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            Debug.Log("finished");
            gameObject.SetActive(false);
        }
        private void Diactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}

