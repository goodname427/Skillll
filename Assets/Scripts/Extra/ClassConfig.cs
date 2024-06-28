using System.Collections.Generic;
using UnityEngine;

namespace Skillll
{
    [CreateAssetMenu(fileName = "Class Config", menuName = "Class/Class Config", order = 1)]
    public class ClassConfig : ScriptableObject
    {
        [SerializeField, Tooltip("Ĭ�ϰ����������ռ�, ��ʹ�÷����ȡ��ʱ�᳢������Щ�����ռ���Ѱ��")]
        private string[] _includeNamespaces;

        public IEnumerable<string> IncludeNamespaces => _includeNamespaces;
    }
}