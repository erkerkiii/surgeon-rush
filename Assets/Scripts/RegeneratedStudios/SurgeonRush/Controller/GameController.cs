using UnityEngine;
using UnityEngine.SceneManagement;

namespace RegeneratedStudios.SurgeonRush.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _winScreen;

        private PlayerController _playerController;
        
        private void Start()
        {
            Time.timeScale = 1;
            InitializeDependencies();
            ListenEvents();
        }

        private void InitializeDependencies()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void ListenEvents()
        {
            HealthController.OnEntityDiedEvent += OnEntityDied;
        }

        private void OnEntityDied(GameObject entity)
        {
            if (entity.GetComponent<PlayerController>() != null)
            {
                ReloadGame();
                return;
            }

            _playerController.GetComponent<HealthController>().Heal(1);

            Invoke(nameof(CheckGameEnd), 1f);
        }

        private void CheckGameEnd()
        {
            int enemiesInScene = FindObjectsOfType<EnemyController>().Length;
            if (enemiesInScene == 0)
            {
                OnGameWin();
            }
        }

        public void ReloadGame()
        {
            SceneManager.LoadSceneAsync(0);
        }

        private void OnGameWin()
        {
            _winScreen.SetActive(true);
            Time.timeScale = 0;
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void UnsubscribeFromEvents()
        {
            HealthController.OnEntityDiedEvent -= OnEntityDied;
        }
    }
}