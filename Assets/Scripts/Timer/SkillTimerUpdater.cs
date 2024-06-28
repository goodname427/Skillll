using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skillll
{
    public class SkillTimerUpdater : MonoBehaviour
    {
        #region Sigleton
        private static SkillTimerUpdater s_instance;

        public static SkillTimerUpdater Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new GameObject("SKILL_TIMER_UPDATER").AddComponent<SkillTimerUpdater>();
                    if (s_instance == null)
                    {
                        Debug.LogError("SKILL_TIMER_UPDATER Can Not Create!");
                    }
                }

                return s_instance;
            }
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
