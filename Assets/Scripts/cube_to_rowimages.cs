using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube_to_rowimages : MonoBehaviour
{
    public GameObject Canvas_Album;

    // Start is called before the first frame update
    public void Init()
    {
        Canvas_Album.SetActive(false);

    }

    public void Click()
    {
        if (!Canvas_Album.activeInHierarchy)
        {
            Canvas_Album.SetActive(true);
        }
        else
        {
            Canvas_Album.SetActive(false);
        }


    }
}
