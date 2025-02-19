namespace KarpysDev.TGarou
{
    using System;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Character", fileName = "CharacterInfo", order = 0)]
    public class CharacterInformations : ScriptableObject
    {
        [SerializeField] private string m_Name = String.Empty;
        [SerializeField] private Sprite m_Icon = null;
        [SerializeField] private bool m_IsInfected = false;
        [SerializeField] private int m_InfectedCount = 0;

        public bool IsInfected => m_IsInfected;
        public Sprite Icon => m_Icon;
        public string Name => m_Name;

        public int InfectedCount => m_InfectedCount;
    }
}