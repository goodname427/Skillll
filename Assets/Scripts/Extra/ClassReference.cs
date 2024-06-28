using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Skillll
{
    [Serializable]
    public class ClassReference
    {
        private static ClassConfig s_classConfig = null;
        public static ClassConfig ClassConfig
        {
            get
            {
                if (s_classConfig == null)
                {
                    s_classConfig = Resources.LoadAll<ClassConfig>("/").FirstOrDefault();
                }

                return s_classConfig;
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string ClassName;

        private Type _classType = null;
        /// <summary>
        /// ������
        /// </summary>
        public Type ClassType
        {
            get
            {
                var assembly = Assembly.Load("Assembly-CSharp");
                _classType ??= assembly.GetType(ClassName);

                if (_classType is null)
                {
                    if (ClassConfig != null)
                    {
                        foreach (var @namespace in ClassConfig.IncludeNamespaces)
                        {
                            _classType = assembly.GetType(@namespace + "." + ClassName);
                            if (_classType is not null)
                            {
                                break;
                            }
                        }
                    }

                    if (_classType is null)
                    {
                        Debug.LogError($"Can Not Find Class({ClassName})");
                    }
                }

                return _classType;
            }
        }
    }
}
