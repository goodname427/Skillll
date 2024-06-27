using UnityEngine;

namespace Skillll
{
    public class CooldownTimer : SkillTimer
    {
        public float Cooldown { get; set; }

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
