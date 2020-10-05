using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.View
{
    public class LevelColorView : AbstractView
    {
        [System.Serializable]
        private struct Mats
        {
            public Material mat;
            public string shaderProperty;
        }

        [SerializeField] private Mats[] mats;
        [SerializeField] private Color[] emissiveColors;

        private int[] shaderIds = null;

        private GameModel gameModel = null;
        private int currentColor = 0;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();

            gameModel.OnLapUpdated += OnLapUpdated;

            GetShaderIds();
            ChangeEmissiveColor();
        }

        private void GetShaderIds()
        {
            shaderIds = new int[mats.Length];

            for (int i = 0; i < shaderIds.Length; ++i)
            {
                shaderIds[i] = Shader.PropertyToID(mats[i].shaderProperty);
            }
        }

        private void OnLapUpdated(int lap)
        {
            ChangeEmissiveColor();
        }

        private void ChangeEmissiveColor()
        {
            for (int i = 0; i < mats.Length; ++i)
            {
                mats[i].mat.SetColor(shaderIds[i], emissiveColors[currentColor]);
            }

            currentColor++;

            if (currentColor > emissiveColors.Length - 1)
            {
                currentColor = 0;
            }
        }

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= OnLapUpdated;
        }
    }
}