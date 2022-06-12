using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube_to_button : MonoBehaviour
{
   
    public GameObject testCanvas;

    // Start is called before the first frame update
    public void Init()
    {
        testCanvas.SetActive(false);

    }

    public void Click()
    {
        if (!testCanvas.activeInHierarchy)
        {
            testCanvas.SetActive(true);
        }
        else {
            testCanvas.SetActive(false);
        }

        
    }
}
