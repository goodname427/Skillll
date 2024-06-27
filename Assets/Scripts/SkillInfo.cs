using System;
using UnityEngine;

namespace Skillll
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "Skill/New Skill", order = 1)]
    public class SkillInfo : ScriptableObject
    {
        [SerializeField]
        string _name;
        [SerializeField]
        string _description;
        [SerializeField]
        ClassReference _skillImplClass;
        [SerializeField]
        float _skillCooldown;
        
        public string Name => _name;
        public string Description => _description;
        public Type SkillImplType => _skillImplClass.ClassType;
        public float SkillCooldown => _skillCooldown;
    }
}
