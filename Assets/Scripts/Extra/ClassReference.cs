using System;
using System.Reflection;
using UnityEngine;

namespace Skillll
{
    [Serializable]
    public class ClassReference
    {
        public string ClassName;

        private Type _classType = null;

        public Type ClassType
        {
            get
            {
                _classType ??= Assembly.Load("Assembly-CSharp").GetType(ClassName);
                if (_classType is null)
                {
                    Debug.LogError($"Can Not Find Class({ClassName})");
                }

                return _classType;
            }
        }
    }
}
