using System;
using UnityEngine;

namespace Skillll
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "Skill/New Skill", order = 1)]
    public class SkillInfo : ScriptableObject
    {
        [SerializeField, Tooltip("��������")]
        string _name;
        [SerializeField, Tooltip("��������")]
        string _description;
        [SerializeField, Tooltip("����ʵ����")]
        ClassReference _skillImplClass;
        [SerializeField, Tooltip("������ȴ")]
        float _skillCooldown;
        
        public string Name => _name;
        public string Description => _description;
        public Type SkillImplType => _skillImplClass.ClassType;
        public float SkillCooldown => _skillCooldown;
    }
}
