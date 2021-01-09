using UnityEngine;

namespace TheDark
{
    public class RotateByInput : MonoBehaviour
    {
        [SerializeField] private FloatVariable speed;

        private void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * speed.RuntimeValue);
        }
    }
}
