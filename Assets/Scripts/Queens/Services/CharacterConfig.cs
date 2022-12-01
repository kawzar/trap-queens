using UnityEngine;

namespace Queens.Services
{
    [CreateAssetMenu]
    public class CharacterConfig : ScriptableObject
    {
        public Sprite Image;
        public string CharacterName;
    }
}