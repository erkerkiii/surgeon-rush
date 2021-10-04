using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class EnemyController : CharacterController
    {
        private Transform _target;

        private const float ATTACK_RANGE = 2f;

        protected override void Start()
        {
            base.Start();
            FindTarget();
            InvokeRepeating(nameof(Attack), 1f, 1f);
        }

        private void Attack()
        {
            if (Vector3.Distance(transform.position, _target.position) > ATTACK_RANGE)
            {
                return;
            }
            
            _target.GetComponent<HealthController>().Damage(CharacterStats.baseDamage);
        }
        
        private void FindTarget()
        {
            _target = FindObjectOfType<PlayerController>().transform;
        }

        private void Update()
        {
            ChaseTarget();
        }

        private void ChaseTarget()
        {
            Vector2 moveDirection = (_target.position - transform.position).normalized;
            _movementController.currentMoveDirection = moveDirection;
        }

        public void Damage(int amount)
        {
            _healthController.Damage(amount);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, ATTACK_RANGE);
        }
    }
}
