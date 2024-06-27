using System;
using UnityEngine;

namespace Skillll
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "Skill/New Skill", order = 1)]
    public class SkillInfo : ScriptableObject
    {
        [SerializeField, Tooltip("技能名称")]
        string _name;
        [SerializeField, Tooltip("技能描述")]
        string _description;
        [SerializeField, Tooltip("技能实现类")]
        ClassReference _skillImplClass;
        [SerializeField, Tooltip("技能冷却")]
        float _skillCooldown;
        
        public string Name => _name;
        public string Description => _description;
        public Type SkillImplType => _skillImplClass.ClassType;
        public float SkillCooldown => _skillCooldown;
    }
}
