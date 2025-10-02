using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameUI gameUI;

    private float scoreAI = 0;
    private float scorePlayer = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(scoreAI >= 10)
        {
            Debug.Log("Bạn đã thua");
        }
        if(scorePlayer >= 10)
        {
            Debug.Log("Bạn đã thắng");
        }
    }

    public void IncreaseScoreAI()
    {
        scoreAI++;
        gameUI.setScoreAIText(scoreAI);
    }
    public void IncreaseScorePlayer()
    {
        scorePlayer++;
        gameUI.setScorePlayerText(scorePlayer);
    }
}
