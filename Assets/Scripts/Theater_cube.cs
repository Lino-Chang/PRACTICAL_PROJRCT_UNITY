using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theater_cube : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject Canvas_Features;
	public GameObject Canvas_Mov;
	
	public void Next()
	{
		Canvas_Features.SetActive(false);
		Canvas_Mov.SetActive(true);
	}
	
	public void End()
	{
		Canvas_Mov.SetActive(false);
	}
	
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
