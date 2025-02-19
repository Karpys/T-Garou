namespace KarpysDev.TGarou
{
    using UnityEngine;
    using UnityEngine.UI;

    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterInformations m_CharacterInformations = null;
        [SerializeField] private Image m_CharacterImage = null;

        private bool m_IsInfected = false;
        private int m_InfectedCount = 0;

        
        //Reset every day
        private bool m_IsProtected = false;
        private void Awake()
        {
            m_CharacterImage.sprite = m_CharacterInformations.Icon;
            m_IsInfected = m_CharacterInformations.IsInfected;
            m_InfectedCount = m_CharacterInformations.InfectedCount;
        }

        private void DayReset()
        {
            m_IsProtected = false;
        }

        public void ApplyInfection(int infectionCount)
        {
            //Patient zero case
            if(m_InfectedCount == -1)
                return;

            m_IsInfected = true;
            m_InfectedCount = infectionCount;
        }

        public void Heal()
        {
            m_IsInfected = false;
            m_InfectedCount = 0;
        }

        public void Protect()
        {
            m_IsProtected = true;
        }
    }
    
    public class CharacterRouletteDisplayer : MonoBehaviour
    {
        [SerializeField] private Transform[] m_Characters = null;
        [SerializeField] private float m_Radius = 1;
        [SerializeField] private float m_Offset = 0;

        private void OnDrawGizmos()
        {
            Rearrange();
        }

        private void Rearrange()
        {
            int count = m_Characters.Length;
            for (int i = 0; i < count; i++)
            {
                float angle = i * (2 * Mathf.PI / count);
                angle += m_Offset;
                float x = Mathf.Cos(angle) * m_Radius;
                float y = Mathf.Sin(angle) * m_Radius;

                m_Characters[i].localPosition = new Vector3(x, y, 0);
            }
        }
    }
}
