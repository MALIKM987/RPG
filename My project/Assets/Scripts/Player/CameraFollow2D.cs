using UnityEngine;

namespace RPG.Player
{
    public class CameraFollow2D : MonoBehaviour
    {
        [Header("Target")]
        public Transform target;

        [Header("Follow Settings")]
        public Vector3 offset = new Vector3(0f, 0f, -10f);
        public float smoothSpeed = 5f;

        private void LateUpdate()
        {
            if (target == null)
            {
                return;
            }

            // LateUpdate runs after player movement, so the camera follows the final position.
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
