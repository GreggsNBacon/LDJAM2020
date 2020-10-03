using UnityEngine;

namespace LudumDare.Core
{
    public class InitializeGame : MonoBehaviour
    {
        private void Awake()
        {
            Models.InitialiseModels();
        }
    }
}