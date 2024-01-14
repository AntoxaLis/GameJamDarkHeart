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
        rb.velocity = transform.right * shootForce;

    }

    void ShootParabolic()
    {
        GameObject projectile = Instantiate(secondProjectileType, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        Vector2 shootDirection = new Vector2(1, 1).normalized; // Adjust the direction as needed
        rb.velocity = shootDirection * shootForce;

        // Optionally, you can add additional logic here for the parabolic trajectory
    }
}