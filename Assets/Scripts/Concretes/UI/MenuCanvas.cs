using System;
using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using UnityEngine;

namespace TileVania.UI
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] private MenuPanel menuPanel;
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
            menuPanel.gameObject.SetActive(isActive);
        }
    }
}

