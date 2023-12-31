using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    public Transform[] waypoints;
    public int arrayLength = 10; // Panjang array yang Anda inginkan
    public int minRange = 1; // Rentang minimum
    public int maxRange = 40; // Rentang maksimum
    public int[] QuestValue; // Array untuk menyimpan angka-angka acak
    public int minNomor = 1, maxNomor = 29;
    public int[] QuestNomorValue;
    public GameObject[] soalIndex;

    public GameObject[] questMarkers;

    public int currentPlayer1Position;
    public int currentPlayer2Position;

    public FollowThePath player1Pos, player2Pos;

    void Start()
    {
        GenerateRandomNumbers();
        GenerateSoalRandomNumbers();

        for (int i = 0; i < QuestValue.Length; i++)
        {
            questMarkers[i].transform.position = new Vector3(waypoints[QuestValue[i] - 1].position.x, waypoints[QuestValue[i] - 1].position.y, waypoints[0].position.z);
        }
    }

    private void Update()
    {
        currentPlayer1Position = player1Pos.waypointIndex;
        currentPlayer2Position = player2Pos.waypointIndex;

        for (int i = 0;i < questMarkers.Length;i++)
        {
            if (QuestValue[i] == -100)
            {
                Destroy(questMarkers[i]);
            }
        }
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

    void GenerateSoalRandomNumbers()
    {
        for (int i = 0; i < arrayLength; i++)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(minNomor, maxNomor + 1);
            } while (ArrayContains(QuestNomorValue, randomNumber));

            QuestNomorValue[i] = randomNumber;
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
