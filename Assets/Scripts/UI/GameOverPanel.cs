using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour {
    public Text PlayerScoreText;
    private void Update()
    {
        if (PlayerScoreText != null)
        {
            PlayerScoreText.text = string.Format("Score: {0}", Model.Instance.PlayerScore);
        }
    }
}
