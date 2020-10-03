using UnityEngine;

namespace LudumDare.Controller
{
    public class CameraController : AbstractController
    {
        [SerializeField] private Camera camera = null;
        [SerializeField] private Vector3 positionOffset = Vector3.zero;
        [SerializeField] private Transform carTransform = null;

        private void Update()
        {
            transform.position = carTransform.position + positionOffset;
            Quaternion newRot = Quaternion.RotateTowards(transform.rotation, carTransform.rotation, 1.0f * Time.deltaTime);

            newRot = new Quaternion(transform.rotation.x, newRot.y, transform.rotation.z, 0.0f);

            transform.rotation = newRot;
        }
    }
}