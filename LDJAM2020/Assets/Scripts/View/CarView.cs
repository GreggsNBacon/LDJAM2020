using LudumDare.Core;
using LudumDare.Model;
using UnityEngine;
using LudumDare.Core.EventManager;
using UnityEngine.Rendering;

namespace LudumDare.View
{
    public class CarView : AbstractView
    {
        [SerializeField] private Transform carTransform = null;
        [SerializeField] private LayerMask mask;

        [SerializeField] private AudioSource engineAudioSource = null;
        [SerializeField] private AudioSource soundsAudioSource = null;

        private GameModel gameModel = null;
        private CarModel carModel = null;
        private AudioModel audioModel = null;
        private RaycastHit hit = new RaycastHit();

        private bool deathConditionMet = false;
        private float timer = 0.0f;

        protected override void Start()
        {
            base.Start();

            gameModel = Models.GetModel<GameModel>();
            carModel = Models.GetModel<CarModel>();
            audioModel = Models.GetModel<AudioModel>();

            gameModel.OnLapUpdated += PlayerForceFieldAudio;
            carModel.OnTurningUpdated += OnTurningUpdated;

            PlayCarEngineAudio();

            EventManager<Events>.RegisterEvent(Events.FailConditionMet, OnDeathConditionMet);
        }

        private void PlayCarEngineAudio()
        {
            engineAudioSource.clip = audioModel.GetSound("Shepard-tone");
            engineAudioSource.Play();
        }

        private void PlayerForceFieldAudio(int lap)
        {
            soundsAudioSource.volume = 0.8f;
            soundsAudioSource.PlayOneShot(audioModel.GetSound("NewLap"));
        }

        private void OnDeathConditionMet(Events eventName, object[] objects)
        {
            deathConditionMet = true;

            engineAudioSource.Stop();

            soundsAudioSource.volume = 0.6f;
            soundsAudioSource.PlayOneShot(audioModel.GetSound("death"));
        }

        private void Update()
        {
            float dt = Time.deltaTime;
            
            CalculateCarRotation();
            UpdateForwardMovement(dt);
            UpdateFalling(dt);

            if (deathConditionMet == true)
            {
                LerpCarOnDeath(dt);
            }
        }

        private void LerpCarOnDeath(float dt)
        {
            //Sort of a hack having this in this in the view script, but fuck it and the hard coded 3 seconds
            timer += dt / 3.0f;
            carModel.currentSpeed = Mathf.Lerp(carModel.currentSpeed, 0.0f, timer);
        }

        private void CalculateCarRotation()
        {
            Ray ray = new Ray(carTransform.position, -carTransform.up);
            if (!Physics.Raycast(ray, out hit, 100, mask, QueryTriggerInteraction.Ignore))
            {
                return;
            }

            // Just in case, also make sure the collider also has a renderer
            // material and texture
            MeshCollider meshCollider = hit.collider as MeshCollider;
            if (meshCollider == null || meshCollider.sharedMesh == null)
            {
                return;
            }

            Mesh mesh = meshCollider.sharedMesh;
            Vector3[] normals = mesh.normals;
            int[] triangles = mesh.triangles;

            // Extract local space normals of the triangle we hit
            Vector3 n0 = normals[triangles[hit.triangleIndex * 3 + 0]];
            Vector3 n1 = normals[triangles[hit.triangleIndex * 3 + 1]];
            Vector3 n2 = normals[triangles[hit.triangleIndex * 3 + 2]];

            // interpolate using the barycentric coordinate of the hitpoint
            Vector3 baryCenter = hit.barycentricCoordinate;

            // Use barycentric coordinate to interpolate normal
            Vector3 interpolatedNormal = n0 * baryCenter.x + n1 * baryCenter.y + n2 * baryCenter.z;
            // normalize the interpolated normal
            interpolatedNormal = interpolatedNormal.normalized;

            // Transform local space normals to world space
            Transform hitTransform = hit.collider.transform;
            interpolatedNormal = hitTransform.TransformDirection(interpolatedNormal);

            carTransform.rotation = Quaternion.FromToRotation(carTransform.up, interpolatedNormal) * carTransform.rotation;
#if UNITY_EDITOR
            DrawDebugInfo(interpolatedNormal);
#endif
        }

        private void UpdateForwardMovement(float dt)
        {
            carTransform.position += carTransform.forward * (carModel.currentSpeed * dt);
        }

        private void UpdateFalling(float dt)
        {
            if (hit.distance >= carModel.minGroundDistance)
            {
                carTransform.position = Vector3.MoveTowards(carTransform.position, hit.point, carModel.fallSpeed * dt);
            }
        }

        private void OnTurningUpdated(float turning)
        {
            if (turning != 0.0f)
            {
                carTransform.rotation *= Quaternion.AngleAxis(turning * carModel.rotationSpeed * Time.deltaTime, Vector3.up);
            }
        }

        private void OnThrottleUpdated(float throttle) {}

        protected override void OnDestroy()
        {
            gameModel.OnLapUpdated -= PlayerForceFieldAudio;
            carModel.OnTurningUpdated -= OnTurningUpdated;
            EventManager<Events>.DeregisterEvent(Events.FailConditionMet, OnDeathConditionMet);
        }

#if UNITY_EDITOR
        private void DrawDebugInfo(Vector3 interpolatedNormal)
        {
            Debug.DrawRay(hit.point, interpolatedNormal);
            Debug.DrawRay(hit.point, hit.normal, Color.red);
        }
#endif
    }
}