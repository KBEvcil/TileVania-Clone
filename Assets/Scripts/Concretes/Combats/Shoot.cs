using System.Collections;
using System.Collections.Generic;
using TileVania.Controllers;
using UnityEngine;

namespace TileVania.Combat
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private ProjectileController _projectile;
        [SerializeField] private Transform _shootFrom;

        public void ShootProjectile(float direction)
        {
            ProjectileController projectile = Instantiate(_projectile, _shootFrom.position, Quaternion.identity);
            projectile.SetMotion(direction);
        }
    }
}

