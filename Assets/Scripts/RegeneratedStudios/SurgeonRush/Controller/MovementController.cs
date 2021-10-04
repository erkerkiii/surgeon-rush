using System;
using RegeneratedStudios.SurgeonRush.Model;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class MovementController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private CharacterStats _characterStats;
        
        public Vector2 currentMoveDirection;

        private void Start()
        {
            InitializeDependencies();
        }

        private void InitializeDependencies()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Setup(CharacterStats characterStats)
        {
            _characterStats = characterStats;
        }
        
        private void FixedUpdate()
        {
            PerformMovement();
        }
        
        
        private void PerformMovement()
        {
            if (_characterStats == null)
            {
                return;
            }
            
            float movementSpeed = _characterStats.movementSpeed;
            _rigidbody2D.MovePosition(_rigidbody2D.position +
                                      currentMoveDirection * movementSpeed * Time.fixedDeltaTime);
        }
    }
}