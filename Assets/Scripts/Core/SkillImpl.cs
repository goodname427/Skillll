namespace Skillll
{
    public abstract class SkillImpl
    {
        public virtual void OnInput(Skill skill, InputTimer inputTimer) { }
        public virtual void OnInputing(Skill skill, InputTimer inputTimer) { }
        public virtual void OnInputCompleted(Skill skill, InputTimer inputTimer) { }

        public virtual void OnInvoke(Skill skill, InvokeTimer invokeTimer) { }
        public virtual void OnInvoking(Skill skill, InvokeTimer invokeTimer) { }
        public virtual void OnInvokeCompleted(Skill skill, InvokeTimer invokeTimer) { }

        public virtual void OnCooldown(Skill skill, CooldownTimer cooldownTimer) { }
        public virtual void OnCooldowning(Skill skill, CooldownTimer cooldownTimer) { }
        public virtual void OnCooldownCompleted(Skill skill, CooldownTimer cooldownTimer) { }
    }
}
