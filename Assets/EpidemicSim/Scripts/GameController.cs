using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static float healthValue = 60;
    public Text playerHealth;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        healthValue -= Time.deltaTime;
        playerHealth.text = "Health: " + Mathf.Round(healthValue);

        if(healthValue <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
