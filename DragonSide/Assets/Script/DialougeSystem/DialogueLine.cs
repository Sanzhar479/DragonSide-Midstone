using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem 
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;
        [Header("Time Options")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;
        [Header("Sound Options")]
        [SerializeField] private AudioClip sound;
        [Header("Character Image Options")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image ImageHolder;

        private IEnumerator LineAppear;

        private void Awake()
        {
           
            ImageHolder.sprite = characterSprite;
            ImageHolder.preserveAspect = true;
        }
        private void OnEnable()
        {
            ResetLine();
            LineAppear = WriteTask(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines);
            StartCoroutine(LineAppear);
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textHolder.text != input)
                {
                    StopCoroutine(LineAppear);
                    textHolder.text = input;
                   
                }
                else
                    finished = true;
            }
        }
        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            finished = false;   
        }
    }

  
}
