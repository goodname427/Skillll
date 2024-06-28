using Skillll.Test;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Movement))]
public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private bool _faceRight = true;

    protected SpriteRenderer SpriteRenderer { get; set; }
    protected Movement Movement { get; set; }
    protected Animator Animator { get; set; }

    protected virtual void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Movement = GetComponent<Movement>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Animator.SetFloat("Speed", Movement.Velocity.magnitude);

        if (Movement.Direction.x != 0)
        {
            SpriteRenderer.flipX = Movement.Direction.x < 0 == _faceRight;
        }
    }
}
