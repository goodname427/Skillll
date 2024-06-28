using System;
using UnityEngine;

namespace Skillll
{
    public class Skill : MonoBehaviour
    {
        [SerializeField, Tooltip("技能信息")]
        SkillInfo _skillInfo;

        private SkillImpl _skillImpl;
        /// <summary>
        /// 技能实现
        /// </summary>
        private SkillImpl SkillImpl
        {
            get
            {
                _skillImpl ??= Activator.CreateInstance(_skillInfo.SkillImplType) as SkillImpl;

                if (_skillImpl is null)
                {
                    Debug.LogError($"SkillImpl({_skillInfo.SkillImplType.Name}) Failed To Create");
                }

                return _skillImpl;
            }
        }

        private void Start()
        {
            InitTimer();
        }
        private void OnDestroy()
        {
            _inputTimer.Stop();
            _invokeTimer.Stop();
            _cooldownTimer.Stop();
        }

        #region Timer
        private InputTimer _inputTimer;
        private InvokeTimer _invokeTimer;
        private CooldownTimer _cooldownTimer;

        #region Init Timer
        private void InitTimer()
        {
            _inputTimer = new InputTimer();
            _inputTimer.TimerStart += (timer) => SkillImpl.OnInput(this, timer as InputTimer);
            _inputTimer.TimerUpdate += (timer) => SkillImpl.OnInputing(this, timer as InputTimer);
            _inputTimer.TimerStop += (timer) => SkillImpl.OnInputCompleted(this, timer as InputTimer);

            _invokeTimer = new InvokeTimer();
            _invokeTimer.TimerStart += (timer) => SkillImpl.OnInvoke(this, timer as InvokeTimer);
            _invokeTimer.TimerUpdate += (timer) => SkillImpl.OnInvoking(this, timer as InvokeTimer);
            _invokeTimer.TimerStop += (timer) => SkillImpl.OnInvokeCompleted(this, timer as InvokeTimer);

            _cooldownTimer = new CooldownTimer
            {
                Cooldown = _skillInfo.SkillCooldown
            };
            _cooldownTimer.TimerStart += (timer) => SkillImpl.OnCooldown(this, timer as CooldownTimer);
            _cooldownTimer.TimerUpdate += (timer) => SkillImpl.OnCooldowning(this, timer as CooldownTimer);
            _cooldownTimer.TimerStop += (timer) => SkillImpl.OnCooldownCompleted(this, timer as CooldownTimer);
        }
        #endregion

        #region Control Timer
        public void StartInput()
        {
            if (_cooldownTimer.IsRunning)
            {
                return;
            }

            _inputTimer.Start();
        }

        public void StopInput()
        {
            _inputTimer.Stop();
        }

        public void StartInvoke()
        {
            if (_cooldownTimer.IsRunning)
            {
                return;
            }

            _invokeTimer.Start();
        }

        public void StopInvoke()
        {
            _invokeTimer.Stop();
        }

        public void Cooldown()
        {
            _cooldownTimer.Start();
        }
        #endregion
        #endregion
    }
}
