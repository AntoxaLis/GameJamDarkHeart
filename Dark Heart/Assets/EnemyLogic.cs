using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
   
    [SerializeField] private int health = 5;
    [SerializeField] private float actionInterval = 2f; //2 second interval
    [SerializeField] private float rotationAngle = 180f;
    [SerializeField] private GameObject firstProjectileType;
    [SerializeField] private GameObject secondProjectileType;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 10f;

    void Start()
    {
         transform.Rotate(0f,rotationAngle,0f);
         StartCoroutine(PerformActions());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Disappear();
        }
    }

    void Disappear()
    {
        Destroy(gameObject);
    }

    IEnumerator PerformActions()
    {
        while (true)
        {
            int randomNumber= Random.Range(0,2);
            if(randomNumber == 0){ShootStraight();}
            else{ShootParabolic();}
            yield return new WaitForSeconds(actionInterval);
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
           shootDirection = Quaternion.Euler(0, 0, 60) * shootDirection;
        }
        else{ shootDirection = Quaternion.Euler(0, 0, -60) * shootDirection;}

        
        rb.velocity = shootDirection * shootForce;

    }

}
