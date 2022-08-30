using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLayer : MonoBehaviour
{
    private BoxCollider2D _bc;

    private void Awake()
    {
        _bc = GetComponent<BoxCollider2D>();
    }
    public bool IsTouchingLayer(string layerName)
    {
        return _bc.IsTouchingLayers(LayerMask.GetMask(layerName));
    }

}
