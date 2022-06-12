using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images_array : MonoBehaviour
{
    public RawImage theImage;
    public int limit = 9;
    public Texture[] myTextures = new Texture[9];
    private int currentItem = 0;
    public GameObject Canvas_Album;
    void Start()
    {
        updatescreen();
    }

    public void updatescreen()
    {
        theImage.texture = myTextures[currentItem];
    }

    public void Next_btn()
    {
        currentItem++;

        //check if at end of array
        if (currentItem > limit - 1)
        {
            currentItem = 0;
        }
        //display
        updatescreen();
    }
    public void Back_btn()
    {
        currentItem--;

        //check if at end of array
        if (currentItem < 0)
        {
            currentItem = limit - 1;
        }
        //display
        updatescreen();
    }

    public void Close_btn()
    {
        Canvas_Album.SetActive(false);
    }
}
