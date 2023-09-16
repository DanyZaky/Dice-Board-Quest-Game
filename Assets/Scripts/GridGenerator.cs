using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject prefabObject; // Prefab objek yang akan digunakan dalam grid
    public int rows = 5; // Jumlah baris
    public int columns = 10; // Jumlah kolom
    public float spacingX = 1.0f; // Jarak antara kolom (sepanjang sumbu X)
    public float spacingY = 1.0f; // Jarak antara baris (sepanjang sumbu Y)

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < columns; j++)
            {
                Vector3 position = new Vector3(j * spacingX, i * spacingY, 0); // Hitung posisi objek (X, Y, Z)
                GameObject newObject = Instantiate(prefabObject, position, Quaternion.identity); // Buat objek baru
                newObject.transform.parent = transform; // Jadikan objek anak dari GridContainer
            }
        }
    }
}
