using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using UnityEngine;

public class LoadMenuAndUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.LoadMenuAndUI(1f);    
    }
}
