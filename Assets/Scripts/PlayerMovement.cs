using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public Vector2 startPosition;
    private Vector2 currentPosition;

    private bool isMoveRight, isMoveLeft;
    private int wave;

    private void Start()
    {
        currentPosition = startPosition;
        player.transform.position = new Vector3(currentPosition.x + offset, currentPosition.y + offset, 0);

        isMoveRight = true;
        isMoveLeft = false;
        wave = 1;
    }

    private void Update()
    {
        if (wave % 2 == 0)  //genap
        {
            isMoveRight = false;
            isMoveLeft = true;
        }
        else  //ganjil
        {
            isMoveRight = true;
            isMoveLeft = false;
        }
    }

    public void MovePlayer()
    {
        if (player.transform.position.x == 10 && wave % 2 != 0)
        {
            wave++;
            currentPosition.y = currentPosition.y + offset;
            player.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
        }
        else if(player.transform.position.x == 1 && wave % 2 == 0)
        {
            wave++;
            currentPosition.y = currentPosition.y + offset;
            player.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
        }
        else
        {
            if (isMoveRight)
            {
                currentPosition.x = currentPosition.x + offset;
                player.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
            }

            if (isMoveLeft)
            {
                currentPosition.x = currentPosition.x - offset;
                player.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
            }
        }
    }
}
