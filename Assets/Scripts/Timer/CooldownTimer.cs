using UnityEngine;

namespace Skillll
{
    public class CooldownTimer : SkillTimer
    {
        /// <summary>
        /// ��ȴ
        /// </summary>
        public float Cooldown { get; set; }

        /// <summary>
        /// ʣ����ȴ
        /// </summary>
        public float RemindTime => Cooldown - TimerTime;

        protected override void OnUpdate()
        {
            if (TimerTime > Cooldown)
            {
                Stop();
            }
        }
    }
}
