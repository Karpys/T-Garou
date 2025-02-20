namespace KarpysDev.TGarou
{
    public class SurgeonEvent : IGameEvent
    {
        private BaseCharacter m_ProtectedCharacter = null;
        public void StartEvent()
        {
            ScreenDisplayer.Instance.DisplaySurgeonScreen(this);
            GameEvent.Instance.OnCharacterSelect += OnSelect;
        }

        public void EndEvent()
        {
            GameEvent.Instance.OnCharacterSelect -= OnSelect;
            m_ProtectedCharacter.Protect();
        }

        public void OnSelect(BaseCharacter baseCharacter)
        {
            m_ProtectedCharacter = baseCharacter;
        }
    }
}