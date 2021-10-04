using RegeneratedStudios.SurgeonRush.View;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Model
{
    [CreateAssetMenu(menuName = "Surgeon Rush/Weapon Data", fileName = "New Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        
        public int damage;

        public WeaponView view;
    }
}