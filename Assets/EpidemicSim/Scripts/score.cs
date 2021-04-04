using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text playerScore;

    private void Start()
    {
        playerScore = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Score: " + scoreValue;
        
    }
}
