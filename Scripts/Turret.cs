using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f; // 1 sparo al secondo
    public float detectionRadius = 10f;
    public int projectilesPerShot = 1;
    public float spreadAngle = 15f; // solo per spari multipli

    private float fireCooldown;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRadius)
        {
            // Guarda il player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            // Sparo a cooldown
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        if (projectilesPerShot == 1)
        {
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            proj.GetComponent<Projectile>().Initialize(firePoint.forward);
        }
        else
        {
            float angleStep = spreadAngle / (projectilesPerShot - 1);
            float startAngle = -spreadAngle / 2;

            for (int i = 0; i < projectilesPerShot; i++)
            {
                float angle = startAngle + angleStep * i;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up) * firePoint.rotation;

                GameObject proj = Instantiate(projectilePrefab, firePoint.position, rotation);
                proj.GetComponent<Projectile>().Initialize(rotation * Vector3.forward);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
