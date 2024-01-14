using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRemoval : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile collides with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Optionally, you can add effects or logic before destroying the projectile
            Destroy(gameObject);
        }
    }
}
