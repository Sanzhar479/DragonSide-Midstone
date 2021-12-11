using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : DialogueBaseClass
    {
        public Control Player;
        private IEnumerator dialogueSeq;
        private bool dialogueFinished;
        [SerializeField]private int endDialogNumber;
        private void OnEnable()
        {

            //Debug.Log(Player);
            FindPlayer();
            dialogueSeq = dialogueSequence();

            StartCoroutine(dialogueSeq);
            Player.inDialogue = true;
        }

        protected virtual void FindPlayer()
        {
            Player = FindObjectOfType<Control>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Diactivate();
                Player.inDialogue = false;
                StopCoroutine(dialogueSeq);
                gameObject.SetActive(false);
            }
            
        }
        private IEnumerator dialogueSequence()
        {
            if (!dialogueFinished)
            {
                for (int i = 0; i < transform.childCount - endDialogNumber; i++)
                {
                    Diactivate();

                    transform.GetChild(i).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
                }
            }
            else
            {
                
                for (int i = transform.childCount - endDialogNumber; i < transform.childCount; i++)
                {
                    Diactivate();
                    transform.GetChild(i).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
                }
                
            }
            Debug.Log("finished");

            dialogueFinished = true;
            Player.inDialogue = false;
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

