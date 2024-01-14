using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject firstProjectileType;
    [SerializeField] private GameObject secondProjectileType;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootStraight();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootParabolic();
        }
    }

    void ShootStraight()
    {
        GameObject projectile = Instantiate(firstProjectileType, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = shootPoint.right * shootForce;

    }

    void ShootParabolic()
    {
        GameObject projectile = Instantiate(secondProjectileType, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        Vector2 shootDirection = shootPoint.right.normalized;
        if (Mathf.Approximately(shootDirection.x, 1.0f) && Mathf.Approximately(shootDirection.y, 0.0f))
        {
           shootDirection = Quaternion.Euler(0, 0, 45) * shootDirection;
        }
        else{ shootDirection = Quaternion.Euler(0, 0, -45) * shootDirection;}

        
        rb.velocity = shootDirection * shootForce;

    }
}