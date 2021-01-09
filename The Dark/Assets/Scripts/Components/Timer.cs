using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace TheDark
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private IntVariable currentTimeInSeconds;
        [SerializeField] private GameEvent timeOverEvent;

        private string startText;

        private TextMeshProUGUI timerText;        

        private void Start()
        {
            timerText = GetComponent<TextMeshProUGUI>();
            startText = timerText.text;

            currentTimeInSeconds.RuntimeValue = currentTimeInSeconds.InitialValue;

            UpdateText();

            StartCoroutine(DecreaseTimeCoroutine());
        }

        private IEnumerator DecreaseTimeCoroutine()
        {
            while (currentTimeInSeconds.RuntimeValue > 0)
            {
                yield return new WaitForSeconds(1.0f);

                currentTimeInSeconds.RuntimeValue--;

                UpdateText();
            }

            timeOverEvent?.Raise();
        }

        private void UpdateText() =>
            timerText.SetText(string.Format(startText, 
                                            currentTimeInSeconds.RuntimeValue.SecondsToTimeString()));
    }
}
