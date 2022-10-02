using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Instructions Panel
Name: Chloe Ma 
Student #: 101260013
Date last modified: 02/10/22
Description: Controls the Instructions Panel's image and text displays.
 */
public class InstructionsPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI descriptionDisplay;
    [SerializeField]
    private Image imageDisplay;
    public string[] descriptions;
    public Sprite[] images;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // updates the displays of the description and image
        if(index < descriptions.Length)
        {
            descriptionDisplay.text = descriptions[index];
            imageDisplay.sprite = images[index];
        }
    }
    public void NextPage()
    {
        // increases the index
        if (index < descriptions.Length)
        {
            index++;
        }
    }
    public void ResetPages()
    {
        // resets the index
        index = 0;
    }
}
