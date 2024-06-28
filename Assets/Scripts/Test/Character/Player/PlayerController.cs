using UnityEngine;

namespace Skillll.Test
{
    public class PlayerController : MonoBehaviour
    {
        private Movement _movement;

        private void Start()
        {
            _movement = GetComponent<Movement>();
        }

        public void Update()
        {
            _movement.Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}
