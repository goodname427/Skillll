using UnityEngine;

namespace Skillll.Test
{
    /// <summary>
    /// ����Ч��Ϊ���¼��ͷŲ�������ȴ
    /// </summary>
    public class TestSkill : SkillImpl
    {
        public override void OnInput(Skill skill, InputTimer inputTimer)
        {
            skill.StartInvoke();
        }

        public override void OnInvoke(Skill skill, InvokeTimer invokeTimer)
        {
            // ===ʵ�ʼ���Ч��===
            Debug.Log("You Invoke The Skill!");
            // =================

            skill.StopInvoke(); // ֹͣ����
            skill.Cooldown();   // ��ʼ��ȴ
        }
    }
}
