using System;
using UnityEngine;

namespace Skillll
{
    public class Skill : MonoBehaviour
    {
        [SerializeField]
        SkillInfo _skillInfo;

        private SkillImpl _skillImpl;

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

        private CooldownTimer _cooldownTimer;
        private InvokeTimer _invokeTimer;
        private InputTimer _inputTimer;

        private void Start()
        {
            _inputTimer = SkillTimerManager.Instance.CreateTimer<InputTimer>();
            _inputTimer.TimerStart += (timer) => SkillImpl.OnInput(this, timer as InputTimer);
            _inputTimer.TimerUpdate += (timer) => SkillImpl.OnInputing(this, timer as InputTimer);
            _inputTimer.TimerStop += (timer) => SkillImpl.OnInputCompleted(this, timer as InputTimer);

            _invokeTimer = SkillTimerManager.Instance.CreateTimer<InvokeTimer>();
            _invokeTimer.TimerStart += (timer) => SkillImpl.OnInvoke(this, timer as InvokeTimer);
            _invokeTimer.TimerUpdate += (timer) => SkillImpl.OnInvoking(this, timer as InvokeTimer);
            _invokeTimer.TimerStop += (timer) => SkillImpl.OnInvokeCompleted(this, timer as InvokeTimer);

            _cooldownTimer = SkillTimerManager.Instance.CreateTimer<CooldownTimer>();
            _cooldownTimer.Cooldown = _skillInfo.SkillCooldown;
            _cooldownTimer.TimerStart += (timer) => SkillImpl.OnCooldown(this, timer as CooldownTimer);
            _cooldownTimer.TimerUpdate += (timer) => SkillImpl.OnCooldowning(this, timer as CooldownTimer);
            _cooldownTimer.TimerStop += (timer) => SkillImpl.OnCooldownCompleted(this, timer as CooldownTimer);
        }

        // to delete
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartInput();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                StopInput();
            }
        }

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
    }
}
