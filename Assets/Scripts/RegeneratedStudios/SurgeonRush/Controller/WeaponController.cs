using System;
using JetBrains.Annotations;
using RegeneratedStudios.SurgeonRush.Model;
using RegeneratedStudios.SurgeonRush.Utility;
using RegeneratedStudios.SurgeonRush.View;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class WeaponController : MonoBehaviour
    {
        private CharacterStats _characterStats;
        
        [SerializeField]
        private Transform _hitCircleTransform;
        [SerializeField]
        private Transform _weaponGraphicParentTransform;

        [SerializeField]
        private GameObject[] _hitEffects;

        private Animator _animator;
        
        private WeaponView _currentWeaponView;
        
        private WeaponData _currentWeaponData;
        
        private const float HIT_RADIUS = 3f;
        
        public void Setup(CharacterStats characterStats)
        {
            _characterStats = characterStats;
            _animator = GetComponentInChildren<Animator>();
        }
        
        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }

        public void EquipWeapon(WeaponData weaponData)
        {
            _currentWeaponData = weaponData;
            UpdateWeaponGraphic();
        }

        private void UpdateWeaponGraphic()
        {
            if (_currentWeaponView)
            {
                Destroy(_currentWeaponView);
            }

            _currentWeaponView = Instantiate(_currentWeaponData.view, _weaponGraphicParentTransform.position,
                _weaponGraphicParentTransform.rotation, _weaponGraphicParentTransform).GetComponent<WeaponView>();
            _currentWeaponView.Setup(_currentWeaponData);
        }

        private void Attack()
        {
            Collider2D[] collidersHit = Physics2D.OverlapCircleAll(_hitCircleTransform.position, HIT_RADIUS);
            for (int index = 0; index < collidersHit?.Length; index++)
            {
                Collider2D collider = collidersHit[index];
                if (collider.TryGetComponent(out EnemyController enemyController))
                {
                    enemyController.Damage(GetDamage());
                    SpawnHitEffect(collider.ClosestPoint(_hitCircleTransform.position));
                }
            }

            const string attackStateName = "Attack1";
            _animator.Play(attackStateName, -1, 0f);
        }

        private void SpawnHitEffect(Vector2 position)
        {
            Instantiate(_hitEffects.GetRandom(), position, Quaternion.identity);
        }

        private int GetDamage()
        {
            return _characterStats.baseDamage + _currentWeaponData.damage;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_hitCircleTransform.position, HIT_RADIUS);
        }
    }
}