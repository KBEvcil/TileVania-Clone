using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public Animator Animator;
    
    public void CollectAnimation()
    {
        Animator.SetBool("IsCollected", true);
    }
}
