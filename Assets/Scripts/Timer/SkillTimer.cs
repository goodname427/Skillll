using System;
using UnityEngine;

namespace Skillll
{
    public class SkillTimer
    {
        #region Event
        /// <summary>
        /// ��ʱ������ʱ����
        /// </summary>
        public event Action<SkillTimer> TimerStart;
        /// <summary>
        /// ��ʱ������ʱ����
        /// </summary>
        public event Action<SkillTimer> TimerStop;
        /// <summary>
        /// ��ʱ������ʱ����
        /// </summary>
        public event Action<SkillTimer> TimerUpdate;

        /// <summary>
        /// ��ʱ����ʼʱ����
        /// </summary>
        protected virtual void OnStart()
        {

        }
        /// <summary>
        /// ��ʱ��ֹͣʱ����
        /// </summary>
        protected virtual void OnStop()
        {

        }
        /// <summary>
        /// ��ʱ������ʱ����
        /// </summary>
        protected virtual void OnUpdate()
        {

        }
        #endregion

        #region Timer Info
        private readonly SkillTimerUpdater _manager;
        /// <summary>
        /// ��ʱ��ID
        /// </summary>
        public readonly uint TimerID;

        /// <summary>
        /// ��ʱ������ʱ��
        /// </summary>
        public float TimerTime { get; private set; }
        /// <summary>
        /// ��ʱ���Ƿ���������
        /// </summary>
        public bool IsRunning { get; private set; }
        #endregion

        #region Control
        /// <summary>
        /// ע���ʱ��
        /// </summary>
        private void Register()
        {
            SkillTimerUpdater.Instance.TimerUpdate += Update;
        }
        /// <summary>
        /// ע����ʱ��
        /// </summary>
        private void Unregister()
        {
            SkillTimerUpdater.Instance.TimerUpdate -= Update;
        }

        /// <summary>
        /// ������ʱ��
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
            TimerStart?.Invoke(this);
            OnStart();
        }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }

            Unregister();
            IsRunning = false;
            TimerStop?.Invoke(this);
            OnStop();
        }

        /// <summary>
        /// ��ʱ������
        /// </summary>
        private void Update()
        {
            TimerTime += Time.deltaTime;
            TimerUpdate?.Invoke(this);
            OnUpdate();
        }
        #endregion

    }
}