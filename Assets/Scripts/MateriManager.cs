using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MateriManager : MonoBehaviour
{
    public int currentIndex;

    public Sprite[] image;
    [TextArea] public string[] description;

    public TextMeshProUGUI descText;
    public Image imageSprite;

    void Start()
    {
        currentIndex = 0;
    }

    void Update()
    {
        currentIndex = Mathf.Clamp(currentIndex, 0, Mathf.Max(image.Length - 1, description.Length - 1));
        descText.text = description[currentIndex];
        imageSprite.sprite = image[currentIndex];
    }

    public void Prev()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = Mathf.Max(image.Length - 1, description.Length - 1);
        }
    }

    public void Next()
    {
        currentIndex++;
        if (currentIndex > Mathf.Max(image.Length - 1, description.Length - 1))
        {
            currentIndex = 0;
        }
    }
}
