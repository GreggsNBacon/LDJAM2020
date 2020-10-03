using UnityEngine;

namespace LudumDare.Controller
{
    public class CameraController : AbstractController
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private float speed = 2.0f;

        // Update is called once per frame
        private void LateUpdate()
        {
            float dt = Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position, dt * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, dt * speed);
        }
    }
}