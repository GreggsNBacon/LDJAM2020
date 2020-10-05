using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.View
{
    public class LevelColorView : AbstractView
    {
        [SerializeField] private Material mat;
        [SerializeField] private Color[] emissiveColors;

        private GameModel gameModel = null;
        private int currentColor = 0;

        private static readonly int EmissionColor = Shader.PropertyToID("Color_354CDE3F");

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();

            gameModel.OnLapUpdated += OnLapUpdated;

            ChangeEmissiveColor();
        }

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= OnLapUpdated;
        }

        private void OnLapUpdated(int lap)
        {
            ChangeEmissiveColor();
        }

        private void ChangeEmissiveColor()
        {
            mat.SetColor(EmissionColor, emissiveColors[currentColor]);

            currentColor++;

            if (currentColor > emissiveColors.Length - 1)
            {
                currentColor = 0;
            }
        }
    }
}