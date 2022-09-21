using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TileVania.Movement
{
    public class Flip : MonoBehaviour
    {
        public float Direction = 1f;
        public void FlipChar(float horizontal)
        {
            if (horizontal == 0) return;
            float signVal = Mathf.Sign(horizontal);
            if (Mathf.Sign(transform.localScale.x) == signVal) return;
            transform.localScale = new Vector2(
                -transform.localScale.x, 
                transform.localScale.y
            );
            Direction = signVal;
        }
    }
}

