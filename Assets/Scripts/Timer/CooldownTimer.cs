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
