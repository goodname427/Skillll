using System;
using UnityEngine;

namespace Skillll
{
    public class SkillTimer
    {
        #region Event
        /// <summary>
        /// 计时器开启时调用
        /// </summary>
        public event Action<SkillTimer> TimerStart;
        /// <summary>
        /// 计时器结束时调用
        /// </summary>
        public event Action<SkillTimer> TimerStop;
        /// <summary>
        /// 计时器运行时调用
        /// </summary>
        public event Action<SkillTimer> TimerUpdate;

        /// <summary>
        /// 计时器开始时调用
        /// </summary>
        protected virtual void OnStart()
        {

        }
        /// <summary>
        /// 计时器停止时调用
        /// </summary>
        protected virtual void OnStop()
        {

        }
        /// <summary>
        /// 计时器更新时调用
        /// </summary>
        protected virtual void OnUpdate()
        {

        }
        #endregion

        #region Timer Info
        private readonly SkillTimerManager _manager;
        /// <summary>
        /// 计时器ID
        /// </summary>
        public readonly uint TimerID;

        /// <summary>
        /// 计时器开启时间
        /// </summary>
        public float TimerTime { get; private set; }
        /// <summary>
        /// 计时器是否处于运行中
        /// </summary>
        public bool IsRunning { get; private set; }
        #endregion

        #region Init
        /// <summary>
        /// 不要显示调用计时器的构造函数, 请使用`TimerManager::CreateTimer`创建计时器
        /// </summary>
        /// <param name="timerID"></param>
        /// <param name="skillTimerManager"></param>
        public SkillTimer(uint timerID, SkillTimerManager skillTimerManager)
        {
            TimerID = timerID;
            _manager = skillTimerManager;
        }

        /// <summary>
        /// 注册计时器
        /// </summary>
        private void Register()
        {
            _manager.TimerUpdate += Update;
        }
        /// <summary>
        /// 注销计时器
        /// </summary>
        private void Unregister()
        {
            _manager.TimerUpdate -= Update;
        }
        #endregion




        #region Control
        /// <summary>
        /// 开启计时器
        /// </summary>
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
        /// <summary>
        /// 结束计时器
        /// </summary>
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

        /// <summary>
        /// 计时器更新
        /// </summary>
        private void Update()
        {
            TimerTime += Time.deltaTime;
            OnUpdate();
            TimerUpdate?.Invoke(this);
        }
        #endregion

    }
}