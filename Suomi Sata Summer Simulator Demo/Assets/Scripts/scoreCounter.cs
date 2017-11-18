using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCounter : MonoBehaviour {

    public int score;   //how many logs have been cut?
    public int logsTotalSpawns;    //how many logs have been spawned in total?
    public GameObject victoryText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            logsTotalSpawns++;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            score++;
        }

        if(logsTotalSpawns >= 21)
        {
            victoryText.GetComponent<TextMesh>().text = "You got " + score.ToString() + " logs out of " + logsTotalSpawns.ToString();
        }
	}
}
