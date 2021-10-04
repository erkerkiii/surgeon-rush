using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Model
{
    [CreateAssetMenu(menuName = "Surgeon Rush/Character Stats", fileName = "New Character Stats")]
    public class CharacterStats : ScriptableObject
    {
        public int maxHealth;
        public int baseDamage;

        public float movementSpeed;
    }
}