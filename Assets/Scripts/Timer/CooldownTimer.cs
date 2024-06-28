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

        public CooldownTimer(uint timerID, SkillTimerManager skillTimerManager) : base(timerID, skillTimerManager)
        {
        }

        protected override void OnUpdate()
        {
            if (TimerTime > Cooldown)
            {
                Stop();
            }
        }
    }
}
