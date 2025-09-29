using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed = 15f;
    private float currentSpeed;

    private void Start()
    {
        // Tạo hướng và lực ngẫu nhiên
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        currentSpeed = speed;

        if (rb != null)
        {
            rb.velocity = new Vector2(x, y).normalized * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Lấy tọa độ y của bóng
            float ballY = transform.position.y;
            // Lấy tọa độ y của vợt
            float paddleY = collision.gameObject.transform.position.y;
            // Lấy chiều cao của vợt
            float paddleHeight = collision.collider.bounds.size.y;
            // Tính góc bật ra của bóng
            float offset = (ballY - paddleY) / (paddleHeight / 2);

            float directionX = transform.position.x > 0 ? -1 : 1;

            if(rb != null)
            {
                rb.velocity = new Vector2(directionX, offset).normalized * speed;
            }
            speed += 0.5f;
        }
    }
}
