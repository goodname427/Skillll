using System.Collections.Generic;
using UnityEngine;

namespace Skillll
{
    [CreateAssetMenu(fileName = "Class Config", menuName = "Class/Class Config", order = 1)]
    public class ClassConfig : ScriptableObject
    {
        [SerializeField, Tooltip("默认包括的命名空间, 在使用反射获取类时会尝试在这些命名空间中寻找")]
        private string[] _includeNamespaces;

        public IEnumerable<string> IncludeNamespaces => _includeNamespaces;
    }
}