using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public AudioSource sfxButton;
    
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public QuestGenerator qg;

    public TextMeshProUGUI playerText;
    public Button diceButton;
    
    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    public FollowThePath player1Path, player2Path;

    void Start ()
    {
        diceSideThrown = 0;
        player1StartWaypoint = 0;
        player2StartWaypoint = 0;
        gameOver = false;
        
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        Time.timeScale = 1;
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
                    //Soal.SetActive(true);
                    qg.soalIndex[qg.QuestNomorValue[i] - 1].SetActive(true);
                    qg.QuestValue[i] = -100;
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

        if(!player1Path.moveAllowed || !player2Path.moveAllowed)
        {
            if (player1.GetComponent<FollowThePath>().waypointIndex ==
            player1.GetComponent<FollowThePath>().waypoints.Length)
            {
                gameOverPanel.SetActive(true);
                Debug.Log("Player 1 Wins");
                gameOverText.text = "Player 1 Wins";
                gameOver = true;
            }

            if (player2.GetComponent<FollowThePath>().waypointIndex ==
                player2.GetComponent<FollowThePath>().waypoints.Length)
            {
                gameOverPanel.SetActive(true);
                Debug.Log("Player 2 Wins");
                gameOverText.text = "Player 2 Wins";
                gameOver = true;
            }
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                player1.GetComponent<FollowThePath>().moveReverseAllowed = false;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                player2.GetComponent<FollowThePath>().moveReverseAllowed = false;
                break;
        }
    }

    public static void MoveReversePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowThePath>().waypointIndex -= 2;
                player1.transform.position = player1.GetComponent<FollowThePath>().waypoints[player1.GetComponent<FollowThePath>().waypointIndex-1].transform.position;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().waypointIndex -= 2;
                player2.transform.position = player2.GetComponent<FollowThePath>().waypoints[player2.GetComponent<FollowThePath>().waypointIndex-1].transform.position;
                break;
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SFXButton();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        SFXButton();
    }

    public void SFXButton()
    {
        sfxButton.Play();
    }
}
