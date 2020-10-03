using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;
using static LudumDare.Model.GameModel;

namespace LudumDare.Controller
{
    public class FollowController : AbstractController
    {
        private GameModel gameModel = null;
        private PositionalData posData = null;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();

            posData = gameModel.first;
        }

        private void LateUpdate()
        {
            if (posData == null)
            {
                posData = gameModel.first;
            }
            else
            {
                transform.position = posData.Position;
                transform.rotation = Quaternion.Euler(posData.Rotation);
                posData = posData.next;
            }
        }

        protected override void OnDestroy()
        {
        }
    }
}