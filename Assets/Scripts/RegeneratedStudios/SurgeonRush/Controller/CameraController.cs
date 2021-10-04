using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerTransform;

        private void FixedUpdate()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            const float followSpeed = 1.5f;
            const float zOffset = -10f;

            Vector3 desiredPosition = _playerTransform.position;
            desiredPosition.z = zOffset;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * followSpeed);
        }
    }
}
