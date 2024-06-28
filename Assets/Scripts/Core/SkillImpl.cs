namespace Skillll
{
    public abstract class SkillImpl
    {
        public virtual void OnInputed(Skill skill, InputTimer inputTimer) { }
        public virtual void OnInputing(Skill skill, InputTimer inputTimer) { }
        public virtual void OnInputCompleted(Skill skill, InputTimer inputTimer) { }

        public virtual void OnInvoked(Skill skill, InvokeTimer invokeTimer) { }
        public virtual void OnInvoking(Skill skill, InvokeTimer invokeTimer) { }
        public virtual void OnInvokeCompleted(Skill skill, InvokeTimer invokeTimer) { }

        public virtual void OnCooldowned(Skill skill, CooldownTimer cooldownTimer) { }
        public virtual void OnCooldowning(Skill skill, CooldownTimer cooldownTimer) { }
        public virtual void OnCooldownCompleted(Skill skill, CooldownTimer cooldownTimer) { }
    }
}
