using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty difficulty;

    public Transform ball;
    public Rigidbody2D rb;

    public float easySpeed = 6f;
    public float easyDeadzone = 2f;

    public float mediumSpeed = 8f;
    public float mediumDeadzone = 1f;

    public float hardSpeed = 10f;
    public float hardDeadzone = 0.05f;

    private float speed;

    private void FixedUpdate()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                HandleEasyAI();
                break;
            case Difficulty.Medium:
                HandleMediumAI();
                break;
            case Difficulty.Hard:
                HandleHardAI();
                break;
        }
    }

    private void HandleEasyAI()
    {
        speed = easySpeed;
        float diff = ball.position.y - transform.position.y;

        if (Mathf.Abs(diff) > easyDeadzone)
        {
            // Easy AI thỉnh thoảng "lười" không di chuyển
            if (Random.value > 0.1f)
            {
                float targetY = Mathf.Lerp(transform.position.y, ball.position.y, Time.fixedDeltaTime * speed * 0.5f);
                rb.MovePosition(new Vector2(transform.position.x, targetY));
            }
        }
    }

    private void HandleMediumAI()
    {
        speed = mediumSpeed;
        float diff = ball.position.y - transform.position.y;

        if (Mathf.Abs(diff) > mediumDeadzone)
        {
            // Medium AI di chuyển mượt hơn Easy
            float targetY = Mathf.SmoothDamp(
                transform.position.y,
                ball.position.y,
                ref diff,
                0.2f,
                speed,
                Time.fixedDeltaTime
            );
            rb.MovePosition(new Vector2(transform.position.x, targetY));
        }
    }

    private void HandleHardAI()
    {
        speed = hardSpeed;
        float diff = ball.position.y - transform.position.y;

        if (Mathf.Abs(diff) > hardDeadzone)
        {
            float targetY = Mathf.Lerp(transform.position.y, ball.position.y, Time.fixedDeltaTime * speed);

            // Giới hạn bước di chuyển để không rung
            float maxStep = speed * Time.fixedDeltaTime;
            targetY = Mathf.MoveTowards(transform.position.y, targetY, maxStep);

            rb.MovePosition(new Vector2(transform.position.x, targetY));
        }
    }
}
