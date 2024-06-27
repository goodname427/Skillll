using System;
using UnityEngine;

namespace Skillll
{
    public class SkillTimer
    {
        #region Event
        public event Action<SkillTimer> TimerStart;
        public event Action<SkillTimer> TimerStop;
        public event Action<SkillTimer> TimerUpdate;
        #endregion

        #region Timer Info
        private readonly SkillTimerManager _manager;
        public readonly uint TimerID;
        #endregion

        #region Constructor
        public SkillTimer(uint timerID, SkillTimerManager skillTimerManager)
        {
            TimerID = timerID;
            _manager = skillTimerManager;
        }
        #endregion

        public float TimerTime { get; private set; }
        public bool IsRunning { get; private set; }

        private void Register()
        {
            _manager.TimerUpdate += Update;
        }

        private void Unregister()
        {
            _manager.TimerUpdate -= Update;
        }

        public void Start()
        {
            if (IsRunning)
            {
                return;
            }

            Register();
            TimerTime = 0;
            IsRunning = true;
            OnStart();
            TimerStart?.Invoke(this);
        }

        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }

            Unregister();
            IsRunning = false;
            OnStop();
            TimerStop?.Invoke(this);
        }

        private void Update()
        {
            TimerTime += Time.deltaTime;
            OnUpdate();
            TimerUpdate?.Invoke(this);
        }

        protected virtual void OnStart()
        {

        }

        protected virtual void OnStop()
        {

        }

        protected virtual void OnUpdate()
        {

        }
    }
}