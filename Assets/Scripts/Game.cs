using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class Game : MonoBehaviour
    {
        public static Game instance;

        public event Action OnSave;

        [SerializeField] GameOverUI _gameOverUI;


        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            Health.instance.OnDie += GameOver;
            _gameOverUI.Hide();
        }

        void GameOver()
        {
            Time.timeScale = 0f;

            _gameOverUI.Show();

            OnSave.Invoke();
        }

        public void Restart()
        {
            Time.timeScale = 1f;

            SceneManager.LoadScene(0);
        }

        void OnApplicationQuit()
        {
            OnSave.Invoke();
        }
    }
}
