using UnityEngine;

namespace Skillll
{
    public class BindSkill : Skill
    {
        [SerializeField]
        private string _bindButton;

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown(_bindButton))
            {
                StartInput();
            }

            if (UnityEngine.Input.GetButtonUp(_bindButton))
            {
                StopInput();
            }
        }
    }
}