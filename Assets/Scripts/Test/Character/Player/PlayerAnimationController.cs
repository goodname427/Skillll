using UnityEngine;

namespace Skillll.Test
{
    public class PlayerAnimationController : AnimationController
    {
        private Skill[] _skills;

        protected override void Start()
        {
            base.Start();
            _skills = GetComponents<Skill>();
            foreach (var skill in _skills)
            {
                skill.Invoked += OnSkillInvokeStarted;
                skill.InvokeCompleted += OnSkillInvokeStoped;
            }
        }

        protected override void Update()
        {
            base.Update();
        }

        public void OnSkillInvokeStarted(SkillTimer skillTimer)
        {
            Animator.SetBool("Attacking", true);
            Debug.Log("Start Invoke");
        }
        
        public void OnSkillInvokeStoped(SkillTimer skillTimer)
        {
            Animator.SetBool("Attacking", false);
            Debug.Log("Stop Invoke");
        }
    }
}
