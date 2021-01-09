using TMPro;
using UnityEngine;

namespace TheDark
{
    public class TorchesExtinguishedCounter : MonoBehaviour
    {
        [SerializeField] private IntVariable torchesExtinguishedCount;

        private TextMeshProUGUI counterText;
        private string startCounterText;

        private void Start()
        {
            counterText = GetComponent<TextMeshProUGUI>();
            startCounterText = counterText.text;

            torchesExtinguishedCount.RuntimeValue = torchesExtinguishedCount.InitialValue;

            UpdateUI();
        }

        public void IncreaseCount()
        {
            torchesExtinguishedCount.RuntimeValue++;

            UpdateUI();
        }

        private void UpdateUI() =>
            counterText.SetText(string.Format(startCounterText, torchesExtinguishedCount.RuntimeValue));
    }
}
