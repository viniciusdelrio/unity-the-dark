using System.Collections;
using UnityEngine;

namespace TheDark
{
    public class Torch : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private FloatVariable minTimeToSwitchOn;
        [SerializeField] private FloatVariable maxTimeToSwitchOn;

        [Header("Render configurations")]
        [SerializeField] private Material lightOnMaterial;
        [SerializeField] private Material lightOffMaterial;

        [Header("Events")]
        [SerializeField] private GameEvent torchExtinguishedEvent;

        private MeshRenderer meshRenderer;
        private Light torchLight;
        private AudioSource audioSource;

        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            torchLight = GetComponentInChildren<Light>();
            audioSource = GetComponent<AudioSource>();

            RandomTorchState();   
        }

        private void RandomTorchState()
        {
            var random = Random.Range(0, 101);

            if (random % 2 == 0)
                TurnTorchOn();
            else
            {
                TurnTorchOff();
                TurnTorchOnAfterRandomTime();
            }
        }

        private void OnMouseDown()
        {
            if (torchLight.enabled)
            {
                audioSource.Play();

                TurnTorchOff();

                torchExtinguishedEvent?.Raise();

                TurnTorchOnAfterRandomTime();
            }
        }

        private void TurnTorchOnAfterRandomTime() =>
            StartCoroutine(TurnTorchOnAfterRandomTimeCoroutine());

        private IEnumerator TurnTorchOnAfterRandomTimeCoroutine()
        {
            var duration = Random.Range(minTimeToSwitchOn.RuntimeValue, maxTimeToSwitchOn.RuntimeValue);

            yield return new WaitForSeconds(duration);

            TurnTorchOn();
        }

        private void TurnTorchOn()
        {
            torchLight.enabled = true;
            meshRenderer.material = lightOnMaterial;
        }

        private void TurnTorchOff()
        {
            torchLight.enabled = false;
            meshRenderer.material = lightOffMaterial;
        }
    }
}
