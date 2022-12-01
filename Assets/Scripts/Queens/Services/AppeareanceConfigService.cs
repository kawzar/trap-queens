using System.Linq;
using Queens.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Queens.Services
{
    [CreateAssetMenu]
    public class AppeareanceConfigService : ScriptableObject
    {
        [SerializeField]
        private CharacterConfig[] characterConfig;

        public CharacterConfig[] CharacterConfig => characterConfig;

        public Sprite GetCharacterSpriteForCurrentCard()
        {
            return characterConfig.SingleOrDefault(c => c.CharacterName.Equals(DeckSystem.Instance.CurrentCard.Bearer))
                .Image;
        }
    }
}