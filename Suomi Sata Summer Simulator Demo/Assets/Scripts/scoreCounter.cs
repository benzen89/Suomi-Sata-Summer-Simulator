using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCounter : MonoBehaviour {

    public int score;   //how many logs have been cut?
    public int totalSpawns;    //how many logs have been spawned in total?
    public GameObject victoryText;

    public bool woodCuttinginProgress;

	// Use this for initialization
	void Start () {
        woodCuttinginProgress = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            totalSpawns++;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            score++;
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            GameRestart();
        }

        if (totalSpawns >= 10 && woodCuttinginProgress)
        {
            //victoryText.GetComponent<TextMesh>().text = "You got " + score.ToString() + " logs out of " + logsTotalSpawns.ToString();
            GameEnd();
            woodCuttinginProgress = false;
        }
	}

    //Run GameEnd() whenever woodcutting game stops
    public void GameEnd()
    {
        victoryText.GetComponent<TextMesh>().text = "You got " + score.ToString() + " logs out of " + totalSpawns.ToString();
    }

    //Run GameRestart() when woodcutting game starts or restarts
    public void GameRestart()
    {
        score = 0;
        totalSpawns = 0;
        woodCuttinginProgress = true;
        victoryText.GetComponent<TextMesh>().text = "";
        Debug.Log("game restarted");
    }
}
