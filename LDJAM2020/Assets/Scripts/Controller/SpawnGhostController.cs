using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.Controller
{
    public class SpawnGhostController : AbstractController
    {
        [SerializeField] private GameObject objectToSpawn;

        private GameModel gameModel = null;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();
            gameModel.OnLapUpdated += LapUpdated;
        }

        private void LapUpdated(int lap)
        {
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn);
            }
            else
            {
                Debug.LogWarning("Cannot instantiate ghost, game object is null");
            }
        }

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= LapUpdated;
        }
    }
}