using System.Collections;
using RegeneratedStudios.SurgeonRush.Controller;
using RegeneratedStudios.SurgeonRush.Model;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.View
{
    public class HealthBar : MonoBehaviour
    {
        private HealthController _healthController;

        private CharacterStats _characterStats;

        private Coroutine _currentUpdateViewCoroutine;
        
        public void Setup(CharacterStats characterStats)
        {
            _characterStats = characterStats;
            
            _healthController = GetComponentInParent<HealthController>();
            
            ListenEvents();
        }

        private void ListenEvents()
        {
            _healthController.OnHealthValueChangedEvent += OnHealthValueChanged;
        }

        private void OnHealthValueChanged(int value)
        {
            if (_currentUpdateViewCoroutine != null)
            {
                StopCoroutine(_currentUpdateViewCoroutine);
                _currentUpdateViewCoroutine = null;
            }
            
            _currentUpdateViewCoroutine = StartCoroutine(UpdateViewCoroutine());
        }

        private IEnumerator UpdateViewCoroutine()
        {
            Vector3 targetScale = transform.localScale;
            targetScale.x = (float)_healthController.CurrentHealth / (float)_characterStats.maxHealth;
            
            while (transform.localScale != targetScale)
            {
                const float smoothness = 10f;
                transform.localScale =
                    Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * smoothness);

                yield return null;
            }

            transform.localScale = targetScale;
        }

        private void UnsubscribeFromEvents()
        {
            if (_healthController != null)
            {
                _healthController.OnHealthValueChangedEvent -= OnHealthValueChanged;
            }
        }
        
        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }
    }
}