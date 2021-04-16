using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static float healthValue = 60;
    public Text playerHealth;

    public int scoreValue = 0;
    public Text playerScore;

    public int numOfHealthy = 40;
    public Text healthyVictims;

    public int numOfInfected = 1;
    public Text infectedVictims;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Score: " + scoreValue;
        healthyVictims.text = "Healthy: " + numOfHealthy;
        infectedVictims.text = "Infected: " + numOfInfected;

        healthValue -= Time.deltaTime;
        playerHealth.text = "Health: " + Mathf.Round(healthValue);

        if(healthValue <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
