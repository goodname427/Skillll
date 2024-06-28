using UnityEngine;

namespace Skillll.Test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float _maxSpeed = 1.0f;

        public Vector2 Direction { get; set; }
        public Vector2 Velocity { get; set; }
        public float MaxSpeed { get => _maxSpeed; set => _maxSpeed = value; }

        private Rigidbody2D _rigidbody;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Velocity = Direction * MaxSpeed;
            _rigidbody.MovePosition(_rigidbody.position + Velocity);
        }
    }
}
