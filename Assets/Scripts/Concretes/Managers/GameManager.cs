using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TileVania.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float sceneLoadDelay;
        private int _totalScore = 0;
        private int _score = 0;
        public Transform SpawnPoint;

        public event Action<bool> OnSceneChanged;
        public event Action<int> OnScoreChanged;

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if(Instance != null)
            {
                Debug.LogWarning("You cannot instantiate more than one Game Manager!");
                Destroy(gameObject);
            } 
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }


        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(sceneLoadDelay);
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            yield return SceneManager.UnloadSceneAsync(buildIndex);
            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };
            if(levelIndex > 0)
            {
                _totalScore += _score;
            }
            _score = 0;
            UpdateScore();
            OnSceneChanged?.Invoke(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadMenuAndUI(float loadDelay)
        {
            StartCoroutine(LoadMenuAndUIAsync(loadDelay));
        }

        private IEnumerator LoadMenuAndUIAsync(float loadDelay)
        {
            yield return new WaitForSeconds(loadDelay);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(true);
        }

        public void UpdateScore(int score = 0)
        {
            _score += score;
            OnScoreChanged?.Invoke(_totalScore + _score);
        }
    }
}

