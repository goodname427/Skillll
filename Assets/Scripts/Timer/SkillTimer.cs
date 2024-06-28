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
        private readonly SkillTimerManager _manager;
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

        #region Init
        /// <summary>
        /// ��Ҫ��ʾ���ü�ʱ���Ĺ��캯��, ��ʹ��`TimerManager::CreateTimer`������ʱ��
        /// </summary>
        /// <param name="timerID"></param>
        /// <param name="skillTimerManager"></param>
        public SkillTimer(uint timerID, SkillTimerManager skillTimerManager)
        {
            TimerID = timerID;
            _manager = skillTimerManager;
        }

        /// <summary>
        /// ע���ʱ��
        /// </summary>
        private void Register()
        {
            _manager.TimerUpdate += Update;
        }
        /// <summary>
        /// ע����ʱ��
        /// </summary>
        private void Unregister()
        {
            _manager.TimerUpdate -= Update;
        }
        #endregion




        #region Control
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
            OnStart();
            TimerStart?.Invoke(this);
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
            OnStop();
            TimerStop?.Invoke(this);
        }

        /// <summary>
        /// ��ʱ������
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