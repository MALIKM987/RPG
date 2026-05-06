using UnityEngine;

namespace RPG.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController2D : MonoBehaviour
    {
        [Header("Movement")]
        public float moveSpeed = 5f;

        private Rigidbody2D rb;
        private Vector2 moveInput;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Built-in Unity axes support WASD and arrow keys by default.
            // This keeps the first prototype simple and avoids the new Input System for now.
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            // Normalizing prevents diagonal movement from being faster.
            moveInput = new Vector2(horizontal, vertical).normalized;
        }

        private void FixedUpdate()
        {
            // Rigidbody2D movement belongs in FixedUpdate so physics stays stable.
            Vector2 nextPosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(nextPosition);
        }
    }
}
