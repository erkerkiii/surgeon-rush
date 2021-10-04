using RegeneratedStudios.SurgeonRush.Model;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class PlayerController : CharacterController
    {
        [SerializeField]
        private WeaponData _starterWeapon;
        
        private WeaponController _weaponController;

        private Animator _animator;
        
        protected override void InitializeDependencies()
        {
            base.InitializeDependencies();
            
            _animator = GetComponentInChildren<Animator>();
            _weaponController = GetComponent<WeaponController>();
            
            _weaponController.Setup(CharacterStats);
            _weaponController.EquipWeapon(_starterWeapon);
        }
        
        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            _movementController.currentMoveDirection.x = inputX;
            _movementController.currentMoveDirection.y = inputY;
            
            const string isRunning = "isRunning";
            _animator.SetBool(isRunning, inputX != 0f || inputY != 0f);

            if (inputX == 0f)
            {
                return;
            }
            
            Vector3 transformScale = transform.localScale;
            transformScale.x = inputX;
                
            transform.localScale = transformScale;
        }
    }
}