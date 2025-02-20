namespace KarpysDev.TGarou
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class ScreenSimpleCharacterSelector : ScreenDisplay,ICharacterSelector
    {
        [SerializeField] private Button m_NextButton = null;

        private BaseCharacter m_CharacterSelected = null;
        public BaseCharacter CharacterSelected => m_CharacterSelected;
        public void AddNextButtonEvent(UnityAction nextButton)
        {
            m_NextButton.onClick.AddListener(nextButton);
        }

        public override void Display()
        {
            m_NextButton.onClick.RemoveAllListeners();
            base.Display();
        }

        public override void Hide()
        {
            base.Hide();
            GameEvent.Instance.OnCharacterSelect += SelectCharacter;
        }

        private void SelectCharacter(BaseCharacter baseCharacter)
        {
            m_CharacterSelected = baseCharacter;
        }
    }
}