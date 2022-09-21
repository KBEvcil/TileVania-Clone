using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using UnityEngine;

namespace TileVania.UI
{
    public class MenuPanel : MonoBehaviour
    {

        public void StartGameClick()
        {
            GameManager.Instance.LoadScene(1);
        }

        public void ExitGameClick()
        {
            GameManager.Instance.ExitGame();
        }
    }   
}
