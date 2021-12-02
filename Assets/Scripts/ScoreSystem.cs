using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int playerScore = 0;
    public GameObject TimeRemainingUI;
    public GameObject playerScoreUI;

    private void Update()
    {
        TimeRemainingUI.gameObject.GetComponent<Text>().text = ("Time Left:" + TimeRemaining);
        TimeRemainingUI.gameObject.GetComponent<Text>().text = ("Score:" + playerScore);
    }

    // score given once a koopa is killed
    private void OnTriggerEnter2D(Collider2D KillScore)
    {
        Debug.Log("Killed Koopa!");
        CountScore();
    }

    // points given based on how much time is left upon completion
    void CountScore()
    {
        playerScore = playerScore + (TimeRemaining * 10);
        Debug.Log(playerScore);
    }
}
