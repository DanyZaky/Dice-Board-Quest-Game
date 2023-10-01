﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour {

    public GameObject Soal;
    public QuestGenerator qg;

    public TextMeshProUGUI playerText;
    public Button diceButton;
    
    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    // Use this for initialization
    void Start () {

        //whoWinsTextShadow = GameObject.Find("WhoWinsText");
        //player1MoveText = GameObject.Find("Player1MoveText");
        //player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        //whoWinsTextShadow.gameObject.SetActive(false);
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);

        Soal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().moveAllowed == true || player2.GetComponent<FollowThePath>().moveAllowed == true)
        {
            diceButton.interactable = false;
        }
        else
        {
            diceButton.interactable = true;

            for (int i = 1; i < qg.QuestValue.Length; i++)
            {
                if (qg.currentPlayer1Position == qg.QuestValue[i] || qg.currentPlayer2Position == qg.QuestValue[i])
                {
                    Soal.SetActive(true);
                }
            }
        }
        
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            playerText.text = "Player 2";
            Debug.Log("Player 2 Move");
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            Debug.Log("Player 1 Move");
            playerText.text = "Player 1";
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            //whoWinsTextShadow.gameObject.SetActive(true);
            //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            Debug.Log("Player 1 Wins");
            gameOver = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            //whoWinsTextShadow.gameObject.SetActive(true);
            //layer1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(false);
            //whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";

            Debug.Log("Player 2 Wins");
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}
