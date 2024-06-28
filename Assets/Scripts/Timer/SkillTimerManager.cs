using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skillll
{
    public class SkillTimerManager : MonoBehaviour
    {
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

        #region Manage Timer 
        private static uint s_timerID = 0;
        /// <summary>
        /// 计时器ID
        /// </summary>
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
        /// <summary>
        /// 当前绑定的所有计时器
        /// </summary>
        private readonly static Dictionary<uint, SkillTimer> s_skillTimers = new();

        /// <summary>
        /// 创建计时器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateTimer<T>() where T : SkillTimer
        {
            T timer = Activator.CreateInstance(typeof(T), new object[] { TimerID, this }) as T;

            s_skillTimers.Add(timer.TimerID, timer);

            return timer;

        }
        /// <summary>
        /// 移除计时器
        /// </summary>
        /// <param name="timer"></param>
        public void RemoveTimer(SkillTimer timer)
        {
            s_skillTimers.Remove(timer.TimerID);
        }
        #endregion

        #region Update Timer
        /// <summary>
        /// 计时器更新
        /// </summary>
        public event Action TimerUpdate;

        private void Update()
        {
            TimerUpdate?.Invoke();
        }
        #endregion
    }
}
