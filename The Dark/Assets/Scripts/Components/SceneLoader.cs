using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheDark
{
    public class SceneLoader : MonoBehaviour
    {
        public void ReloadScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}