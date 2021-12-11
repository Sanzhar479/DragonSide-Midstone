using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }
        protected IEnumerator WriteTask(string _input, Text textHolder, Color _textColor, Font _textFont, float _delay, AudioClip _sound, float _delayBetweenLines)
        {
            textHolder.color = _textColor;
            textHolder.font = _textFont;

            for (int i = 0; i < _input.Length; i++)
            {
                textHolder.text += _input[i];
                yield return new WaitForSeconds(_delay);
                SoundManager.instance.PlaySound(_sound);
            }
            // yield return new WaitForSeconds(_delayBetweenLines);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            finished = true;
        }

    }

}

