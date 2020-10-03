using UnityEngine;
using UnityEngine.SceneManagement;

namespace LudumDare.Core
{
    public class SceneHandler : MonoBehaviour
    {
        private void Awake()
        {
            LoadScenes();
        }

        private void LoadScenes()
        {
            SceneManager.LoadScene("HUDScene", LoadSceneMode.Additive);
        }
    }
}