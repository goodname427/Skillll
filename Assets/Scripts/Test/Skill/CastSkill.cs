using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Skillll.Test
{
    public class CastSkill : SkillImpl
    {
        public override void OnInputed(Skill skill, InputTimer inputTimer)
        {
            skill.StartInvoke();
        }

        public override void OnInvoked(Skill skill, InvokeTimer invokeTimer)
        {
            skill.StartCoroutine(Cast(skill));
        }

        public IEnumerator Cast(Skill skill)
        {
            yield return new WaitForSeconds(8f / 12);
            
            // ===实际技能效果===
            var spell = Spell.CreateSpell(Resources.Load<Spell>("Prefabs/Spell"));
            var dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - skill.transform.position).normalized;
            spell.Velocity = dir * 10;
            //spell.transform.right = dir;
            spell.transform.position = skill.transform.position;
            // =================

            yield return new WaitForSeconds(4f / 12);
            skill.StopInvoke(); // 停止调用
            skill.Cooldown();   // 开始冷却
        }
    }
}
