using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void PlayAgainButtonClick()
    {
        gameObject.SetActive(false);
        GameManager.Instance.LoadScene();
    }

    public void ReturnToMenuButtonClick()
    {
        GameManager.Instance.LoadMenuAndUI(2f);
    }
}
