using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    public Sprite[] diceSides;
    public Image rend;
    public int whosTurn = 1;
    private bool coroutineAllowed = true;
    public GameControl gameControl;

    public GameObject benarText, salahText;
    public FollowThePath player1Path, player2Path;

    public bool isEnam;

	// Use this for initialization
	private void Start () {
        rend.sprite = diceSides[5];
        isEnam = false;
	}

    public void OnClickDice()
    {
        StartCoroutine("RollTheDice");
        //if (!GameControl.gameOver && coroutineAllowed)
            
    }

    private IEnumerator RollTheDice()
    {
        GameControl.diceSideThrown = 0;
        gameControl.SFXButton();
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            //Debug.Log(randomDiceSide);
            rend.gameObject.GetComponent<Button>().interactable = false;
            yield return new WaitForSeconds(0.05f);
            rend.gameObject.GetComponent<Button>().interactable = true;
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        Debug.Log("jalan sebanyak " + GameControl.diceSideThrown);
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        } else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }

        if(GameControl.diceSideThrown != 6)
        {
            whosTurn *= -1; //switch player
            Debug.Log("ini bukan enam");
            isEnam = false;
        }
        else
        {
            isEnam = true;
        }
        
        coroutineAllowed = true;
    }

    public void JawabanBenar()
    {
        GameControl.diceSideThrown = 2;
        //whosTurn *= -1;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        }
        else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        StartCoroutine(delayActive(benarText, 0.6f));
    }

    public void JawabanSalah()
    {
        //GameControl.diceSideThrown = -2;
        
        if (whosTurn == 1)
        {
            GameControl.MoveReversePlayer(1);
            GameControl.player1StartWaypoint = player1Path.waypointIndex - 1;
        }
        else if (whosTurn == -1)
        {
            GameControl.MoveReversePlayer(2);
            GameControl.player2StartWaypoint = player2Path.waypointIndex - 1;
        }
        StartCoroutine(delayActive(salahText, 0.6f));
    }

    private IEnumerator delayActive(GameObject obj, float delay)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        whosTurn *= -1;
        GameControl.diceSideThrown = 0;
    }
}
