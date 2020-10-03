using System;

namespace LudumDare.Model
{
    public class CarModel : AbstractModel
    {
        public float speed = 10.0f;

        public event Action<int> speedUpdated;
    }
}