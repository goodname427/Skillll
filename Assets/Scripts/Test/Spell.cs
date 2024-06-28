using UnityEngine;

namespace Skillll.Test
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Spell : MonoBehaviour
    {
        public Vector2 Velocity { get; set; }

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = Velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                return;
            }

            GetComponent<Animator>().SetTrigger("Explode");
            _rigidbody.velocity = Vector2.zero;
            Destroy(gameObject, 7f / 12);
        }

        public static Spell CreateSpell(Spell spell)
        {
            return Instantiate(spell);
        }
    }
}
