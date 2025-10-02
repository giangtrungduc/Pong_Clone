using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : MonoBehaviour
{
    public float moveLimit = 6.3f;
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float targetY = Mathf.Clamp(mousePos.y, -moveLimit, moveLimit);

        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }
}
