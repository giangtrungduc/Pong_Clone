using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed = 15f;
    private float currentSpeed;
    private float directionReset = 1;

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        gameObject.SetActive(true);
        float posY = Random.Range(-4f, 4f);
        transform.position = new Vector3(0, posY, 0);

        // Tạo hướng và lực ngẫu nhiên
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        currentSpeed = speed;

        if (rb != null)
        {
            rb.velocity = new Vector2(directionReset, y).normalized * currentSpeed;
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

            // Hướng bóng bật ra
            Vector2 newDir = new Vector2(directionX, offset).normalized;

            // Lấy vận tốc paddle
            float paddleBoost = offset;

            // Áp dụng vận tốc mới
            rb.velocity = newDir * (currentSpeed + paddleBoost);
            currentSpeed += 1f;
        }

        if (collision.gameObject.CompareTag("ZonePlayer"))
        {
            gameObject.SetActive(false);
            directionReset = 1;
            Invoke("ResetBall", 1f);
            GameManager.Instance.IncreaseScoreAI();
        }

        if (collision.gameObject.CompareTag("ZoneAI"))
        {
            gameObject.SetActive(false);
            directionReset = -1;
            Invoke("ResetBall", 1f);
            GameManager.Instance.IncreaseScorePlayer();
        }
    }
}
