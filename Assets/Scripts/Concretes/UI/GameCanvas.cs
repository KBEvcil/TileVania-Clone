using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject gamePlayObject;
    [SerializeField] private GameOverPanel gameOverPanel;
    private void OnEnable()
    {
        GameManager.Instance.OnSceneChanged += HandleSceneChanged;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
    }

    private void HandleSceneChanged(bool isActive)
    {
        gamePlayObject.gameObject.SetActive(!isActive);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
    }
}
