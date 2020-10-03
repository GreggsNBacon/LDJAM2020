using LudumDare.Core;
using LudumDare.Model;

namespace LudumDare.Controller
{
    public class LeadCarPositionsController : AbstractController
    {
        private GameModel gameModel = null;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();
        }

        private void Update()
        {
            gameModel.AddToList(transform.position, transform.rotation.eulerAngles);
        }
    }
}