using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharactersConfig", menuName = "ScriptableObjects/Characters", order = 1)]
    public class CharacterConfig : ScriptableObject
    {
        public float MainCharacterSpeed;
        public float BasicMonsterSpeed;
        public float BasicMonsterRespawnTime;
    }
}
