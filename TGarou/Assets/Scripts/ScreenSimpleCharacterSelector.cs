namespace KarpysDev.TGarou
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class ScreenSimpleCharacterSelector : ScreenDisplay,ICharacterSelector
    {
        [SerializeField] private Button m_NextButton = null;
        [SerializeField] private Image m_CharacterSelectedIcon = null;
        [SerializeField] private TMP_Text m_CharacterSelectedName = null;

        private BaseCharacter m_CharacterSelected = null;
        public BaseCharacter CharacterSelected => m_CharacterSelected;

        public override void Display()
        {
            GameEvent.Instance.OnCharacterSelect += SelectCharacter;
            base.Display();
        }

        public override void Hide()
        {
            base.Hide();
            GameEvent.Instance.OnCharacterSelect -= SelectCharacter;
        }

        private void SelectCharacter(BaseCharacter characterSelected)
        {
            m_CharacterSelected = characterSelected;
            m_CharacterSelectedIcon.sprite = characterSelected.CharacterInformations.Icon;
            m_CharacterSelectedName.text = characterSelected.CharacterInformations.CharacterName;
        }
    }
}