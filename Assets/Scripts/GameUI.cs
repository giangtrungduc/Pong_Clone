using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreAIText;
    public TextMeshProUGUI scorePlayerText;

    public void setScoreAIText(float score)
    {
        if(scoreAIText != null)
        {
            scoreAIText.text = "" + score;
        }
    }
    public void setScorePlayerText(float score)
    {
        if (scorePlayerText != null)
        {
            scorePlayerText.text = "" + score;
        }
    }
}
