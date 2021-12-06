using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static float playerScore = 0;
    public GameObject TimeRemainingUI;
    public GameObject playerScoreUI;
    

    [SerializeField] Text TextVar;
    [SerializeField] float TimeRemaining;
    [SerializeField] public GameObject NoTimeScreen;

    private void Start()
    {
        NoTimeScreen.SetActive(false);
    }

    void Update()
    {
        TimeRemaining -= Time.deltaTime; 
        TextVar.text = $"Time: {TimeRemaining:0}";
       

        if (TimeRemaining <= 0)
        {
            Debug.Log("You've run out of time");
            NoTimeScreen.SetActive(true);
            
        }
      

        //TimeRemainingUI.gameObject.GetComponent<Text>().text = ("Time Left:" + TimeRemaining);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score:" + playerScore);
    }

    // score given once a koopa is killed
    void OnTriggerEnter2D(Collider2D score)
    {
        if(score.gameObject.tag == "Enemy")
        {
            playerScore += 100;       
        }

        if(score.gameObject.tag == "coin")
        {
            playerScore += 10;
            Destroy(score.gameObject);
        }
        
        if(score.gameObject.tag == "Mafia")
        {
            playerScore += 100;
        }

        if(score.gameObject.tag == "Mushroom")
        {
            playerScore += 50;
        }
    }

    // points given based on how much time is left upon completion
    void CountScore()
    {
        playerScore += (TimeRemaining * 10);
        Debug.Log(playerScore);
    }
}
