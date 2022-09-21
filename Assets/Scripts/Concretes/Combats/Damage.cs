using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania.Combat
{
    public class Damage : MonoBehaviour
    {
        public int HitDamage;

        public void HitTarget(Health target)
        {
            target.TakeHit(this);
        }
    }
}

