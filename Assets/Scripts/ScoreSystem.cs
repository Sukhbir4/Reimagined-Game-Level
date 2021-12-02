using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static int playerScore = 0;
    public GameObject TimeRemainingUI;
    public GameObject playerScoreUI;

    [SerializeField] Text TextVar;
    [SerializeField] int TimeRemaining;
    [SerializeField] GameObject deathscreen;

    void Update()
    {
        TextVar.text = $"Time: {TimeRemaining - Time.realtimeSinceStartup:0}";

        if (TimeRemaining < 0.1)
        {
            //Debug.Log("You've run out of time");
            ////mario = gameObject.GetComponent<mario>();
            ////deathScreen.SetActive(true);
        }
   
        TimeRemainingUI.gameObject.GetComponent<Text>().text = ("Time Left:" + TimeRemaining);
        TimeRemainingUI.gameObject.GetComponent<Text>().text = ("Score:" + playerScore);
    }

    // score given once a koopa is killed
    void OnTriggerEnter2D(Collider2D Score)
    {
        if(Score.gameObject.name == "Koopa")
        {
            playerScore += 10;
            CountScore();
        }

        if(Score.gameObject.name == "coin")
        {
            playerScore += 10;
            Destroy(Score.gameObject);
        }
    }

    // points given based on how much time is left upon completion
    void CountScore()
    {
        playerScore = playerScore + (TimeRemaining * 10);
        Debug.Log(playerScore);
    }

    void PlayerRaycast()
    {

    }
}
