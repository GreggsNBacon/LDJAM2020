using UnityEngine;

namespace LudumDare.Controller
{
    [ExecuteAlways]
    public class CameraController : AbstractController
    {
        [SerializeField]
        private Transform target = null;

        [SerializeField]
        private float speed = 2.0f;

        private void Update()
        {
            float dtSpeed = Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, target.position, dtSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, dtSpeed);
        }
    }
}