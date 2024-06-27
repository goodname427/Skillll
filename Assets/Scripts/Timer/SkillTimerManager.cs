using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skillll
{
    public class SkillTimerManager : MonoBehaviour
    {
        public event Action TimerUpdate;

        #region Sigleton
        private static SkillTimerManager s_instance;

        public static SkillTimerManager Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new GameObject("SKILL_TIMER_MANAGER").AddComponent<SkillTimerManager>();
                }

                return s_instance;
            }
        }
        #endregion

        private static uint s_timerID = 0;

        public static uint TimerID
        {
            get
            {
                if (s_timerID >= uint.MaxValue)
                {
                    s_timerID = 0;
                }

                return s_timerID++;
            }
        }

        private readonly static Dictionary<uint, SkillTimer> s_skillTimers = new();

        public T CreateTimer<T>() where T : SkillTimer
        {
            T timer = Activator.CreateInstance(typeof(T), new object[] { TimerID, this }) as T;

            s_skillTimers.Add(timer.TimerID, timer);

            return timer;

        }

        public void RemoveTimer(SkillTimer timer)
        {
            s_skillTimers.Remove(timer.TimerID);
        }

        private void Update()
        {
            TimerUpdate?.Invoke();
        }
    }
}
