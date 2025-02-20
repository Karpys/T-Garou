namespace KarpysDev.TGarou
{
    using UnityEngine;

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
