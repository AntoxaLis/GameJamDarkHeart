using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Tilemap groundTilemap;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Проверка соприкосновения с землей
        isGrounded = IsGrounded();

        // Получение ввода от игрока
        float horizontalInput = Input.GetAxis("Horizontal");

        // Применение силы для движения
        Vector2 moveVelocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // Скользящее движение при отпускании клавиши
        if (horizontalInput == 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        }

        // Прыжок
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 bottomLeft = new Vector2(bounds.min.x, bounds.min.y - 0.1f);
        Vector2 bottomRight = new Vector2(bounds.max.x, bounds.min.y - 0.1f);

        return groundTilemap.HasTile(groundTilemap.WorldToCell(bottomLeft)) ||
               groundTilemap.HasTile(groundTilemap.WorldToCell(bottomRight));
    }
}
