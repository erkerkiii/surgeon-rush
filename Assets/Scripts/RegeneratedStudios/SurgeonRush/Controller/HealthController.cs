using System;
using RegeneratedStudios.SurgeonRush.Model;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class HealthController : MonoBehaviour
    {
        public static event Action<GameObject> OnEntityDiedEvent;
        
        public event Action<int> OnHealthValueChangedEvent; 

        private CharacterStats _characterStats;
        
        private int _currentHealth;
        
        public int CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                OnHealthValueChanged(_currentHealth);
            }
        }

        public void Setup(CharacterStats characterStats)
        {
            _characterStats = characterStats;
            CurrentHealth = _characterStats.maxHealth;
        }

        public void Damage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > _characterStats.maxHealth)
            {
                CurrentHealth = _characterStats.maxHealth;
            }
        }

        private void Die()
        {
            OnEntityDied();
            Destroy(gameObject);
        }
        
        private void OnHealthValueChanged(int value)
        {
            OnHealthValueChangedEvent?.Invoke(value);
        }
        
        private void OnEntityDied()
        {
            OnEntityDiedEvent?.Invoke(gameObject);
        }
    }
}