namespace KarpysDev.TGarou
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class ScreenSimpleCharacterSelector : MonoBehaviour
    {
        [SerializeField] private Button m_NextButton = null;

        public void ResetScreen()
        {
            m_NextButton.onClick.RemoveAllListeners();
        }
        
        public void AddNextButtonEvent(UnityAction nextButton)
        {
            m_NextButton.onClick.AddListener(nextButton);
        }
    }
}