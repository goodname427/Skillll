using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skillll.Test
{

    public class TestSkill : SkillImpl
    {
        public override void OnInput(Skill skill, InputTimer inputTimer)
        {
            skill.StartInvoke();
        }

        public override void OnInvoke(Skill skill, InvokeTimer invokeTimer)
        {
            Debug.Log("You Invoke The Skill!");
            skill.StopInvoke();
            skill.Cooldown();
        }
    }
}
