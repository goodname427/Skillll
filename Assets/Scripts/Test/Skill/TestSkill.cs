using UnityEngine;

namespace Skillll.Test
{
    /// <summary>
    /// ���ܰ��¼��ͷŲ�������ȴ
    /// </summary>
    public class TestSkill : SkillImpl
    {
        public override void OnInputed(Skill skill, InputTimer inputTimer)
        {
            skill.StartInvoke();
        }

        public override void OnInvoked(Skill skill, InvokeTimer invokeTimer)
        {
            // ===ʵ�ʼ���Ч��===
            DoSomething();
            // =================

            skill.StopInvoke(); // ֹͣ����
            skill.Cooldown();   // ��ʼ��ȴ
        }

        private void DoSomething()
        {
            Debug.Log("You Invoke The Skill!");
        }
    }
}
