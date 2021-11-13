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


        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            ImageHolder.sprite = characterSprite;
            ImageHolder.preserveAspect = true;
        }
        private void Start()
        {
            StartCoroutine(WriteTask(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }
    }

}
