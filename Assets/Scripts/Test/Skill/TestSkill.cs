using UnityEngine;

namespace Skillll.Test
{
    /// <summary>
    /// 技能按下即释放并进入冷却
    /// </summary>
    public class TestSkill : SkillImpl
    {
        public override void OnInputed(Skill skill, InputTimer inputTimer)
        {
            skill.StartInvoke();
        }

        public override void OnInvoked(Skill skill, InvokeTimer invokeTimer)
        {
            // ===实际技能效果===
            DoSomething();
            // =================

            skill.StopInvoke(); // 停止调用
            skill.Cooldown();   // 开始冷却
        }

        private void DoSomething()
        {
            Debug.Log("You Invoke The Skill!");
        }
    }
}
