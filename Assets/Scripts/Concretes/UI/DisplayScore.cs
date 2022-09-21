using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
    }

    private void GameManager_OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
