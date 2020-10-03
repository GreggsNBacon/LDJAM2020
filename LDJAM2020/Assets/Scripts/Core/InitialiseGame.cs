using UnityEngine;

namespace LudumDare.Core
{
    public class InitialiseGame : MonoBehaviour
    {
        private void Awake()
        {
            Models.InitialiseModels();
        }
    }
}