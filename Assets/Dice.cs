using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    public Sprite[] diceSides;
    public Image rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

	// Use this for initialization
	private void Start () {
        rend.sprite = diceSides[5];
	}

    public void OnClickDice()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            Debug.Log(randomDiceSide);
            rend.gameObject.GetComponent<Button>().interactable = false;
            yield return new WaitForSeconds(0.05f);
            rend.gameObject.GetComponent<Button>().interactable = true;
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        } else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }

        if(GameControl.diceSideThrown != 6)
        {
            whosTurn *= -1;
            Debug.Log("ini bukan enam");
        }
        
        coroutineAllowed = true;
    }

    public void JawabanBenar()
    {
        GameControl.diceSideThrown = 2;
        whosTurn *= -1;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        }
        else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
    }

    public void JawabanSalah()
    {
        GameControl.diceSideThrown = -2;
        whosTurn *= -1;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        }
        else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
    }
}
