using System.Collections;
using System.Collections.Generic;
using TileVania.Managers;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.Instance.Play("Teleport");
            GameManager.Instance.LoadScene(1);
        }
    }
}
