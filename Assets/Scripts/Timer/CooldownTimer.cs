using UnityEngine;

namespace Skillll
{
    public class CooldownTimer : SkillTimer
    {
        /// <summary>
        /// ¿‰»¥
        /// </summary>
        public float Cooldown { get; set; }

        /// <summary>
        ///  £”‡¿‰»¥
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
