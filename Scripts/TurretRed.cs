using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRed : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public int projectilesPerShot = 5;

    private float fireCooldown;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            ShootCircle();
            fireCooldown = 1f / fireRate;
        }
    }

    void ShootCircle()
    {
        float angleStep = 360f / projectilesPerShot;
        float angle = 0f;

        for (int i = 0; i < projectilesPerShot; i++)
        {
            float dirX = Mathf.Sin(angle * Mathf.Deg2Rad);
            float dirZ = Mathf.Cos(angle * Mathf.Deg2Rad);
            Vector3 dir = new Vector3(dirX, 0, dirZ);

            Quaternion rotation = Quaternion.LookRotation(dir);

            GameObject proj = Instantiate(projectilePrefab, firePoint.position, rotation);
            proj.GetComponent<Projectile>().Initialize(dir);

            angle += angleStep;
        }
    }
}

