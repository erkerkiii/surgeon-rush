using RegeneratedStudios.SurgeonRush.Model;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.View
{
    public class WeaponView : MonoBehaviour
    {
        private WeaponData _weaponData;

        public void Setup(WeaponData weaponData)
        {
            _weaponData = weaponData;
        }
    }
}