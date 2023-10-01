using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    public Transform[] waypoints;
    public GameObject questMarker;
    public int arrayLength = 10; // Panjang array yang Anda inginkan
    public int minRange = 1; // Rentang minimum
    public int maxRange = 40; // Rentang maksimum
    public int[] QuestValue; // Array untuk menyimpan angka-angka acak

    public int currentPlayer1Position;
    public int currentPlayer2Position;

    public FollowThePath player1Pos, player2Pos;

    void Start()
    {
        GenerateRandomNumbers();

        for (int i = 0; i < QuestValue.Length; i++)
        {
            Instantiate(questMarker, new Vector3(waypoints[QuestValue[i]-1].position.x, waypoints[QuestValue[i]-1].position.y, waypoints[0].position.z), Quaternion.identity);
        }
    }

    private void Update()
    {
        currentPlayer1Position = player1Pos.waypointIndex;
        currentPlayer2Position = player2Pos.waypointIndex;
    }

    void GenerateRandomNumbers()
    {
        for (int i = 0; i < arrayLength; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(minRange, maxRange + 1);
            } while (ArrayContains(QuestValue, randomNumber));

            QuestValue[i] = randomNumber;
        }
    }

    bool ArrayContains(int[] array, int value)
    {
        foreach (int element in array)
        {
            if (element == value)
            {
                return true;
            }
        }
        return false;
    }
}
