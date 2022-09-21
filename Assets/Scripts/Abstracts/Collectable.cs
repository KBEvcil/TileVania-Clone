using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected float delay = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OnCollected();
        }
    }

    protected virtual void OnCollected() => Destroy(gameObject, delay);
}
