using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour {

	public int score1 = 0;
	public int score2 = 0;
	public Text player1;
	public Text player2;
	public Text winner;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		player1.text = "Score : " + score1;
		player2.text = "Score : " + score2;
		if (score1 == 5){
			winner.text = "Player1 WINS!";
			Time.timeScale = 0;
		}
		if (score2 == 5){
			winner.text = "Player2 WINS!";
			Time.timeScale = 0;
		}
	}
}
