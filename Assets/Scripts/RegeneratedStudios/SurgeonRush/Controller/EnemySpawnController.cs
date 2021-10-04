using RegeneratedStudios.SurgeonRush.Utility;
using UnityEngine;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _enemies;

        private const int MAX_ENEMY_COUNT = 30;

        private void Start()
        {
            ScheduleEnemySpawn();
        }

        private void ScheduleEnemySpawn()
        {
            Invoke(nameof(SpawnRandomEnemy), Random.Range(1f, 3f));
        }

        private void SpawnRandomEnemy()
        {
            if (FindObjectsOfType<EnemyController>()?.Length >= MAX_ENEMY_COUNT)
            {
                return;
            }

            Instantiate(_enemies.GetRandom(), transform.position, Quaternion.identity);
            
            ScheduleEnemySpawn();
        }
    }
}