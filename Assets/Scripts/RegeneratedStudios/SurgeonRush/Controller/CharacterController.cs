using RegeneratedStudios.SurgeonRush.Model;
using RegeneratedStudios.SurgeonRush.View;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class CharacterController : MonoBehaviour
    {
        protected HealthController _healthController;

        protected MovementController _movementController;
        
        [SerializeField]
        private CharacterStats _characterStats;

        public CharacterStats CharacterStats => _characterStats;

        protected virtual void Start()
        {
            GetComponentInChildren<HealthBar>().Setup(_characterStats);

            InitializeDependencies();
        }

        protected virtual void InitializeDependencies()
        {
            _healthController = GetComponent<HealthController>();
            _movementController = GetComponent<MovementController>();
            
            _healthController.Setup(CharacterStats);
            _movementController.Setup(CharacterStats);
        }
    }
}