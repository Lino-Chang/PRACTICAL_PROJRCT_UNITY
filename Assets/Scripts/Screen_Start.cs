using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Start : MonoBehaviour
{
    
	public GameObject Canvas_Start;
	public GameObject Canvas_choose;
	public GameObject Canvas_Features;
	public GameObject Canvas_Diary;
	public GameObject Canvas_Photo;
	public GameObject Canvas_Chat;  

    // Update is called once per frame
    public void Game_Start()
    {
        Canvas_Start.SetActive(false);
		Canvas_choose.SetActive(true);
    }
	
	public void Game_Go()
    {
        
		Canvas_choose.SetActive(false);
    }
	
	public void Next_Diary()
    {
		Canvas_Features.SetActive(false);
		Canvas_Diary.SetActive(true);
    }
	
	public void Next_Photo()
    {
		Canvas_Diary.SetActive(false);
		Canvas_Photo.SetActive(true);
    }
	
	public void Next_Chat()
    {
		Canvas_Photo.SetActive(false);
		Canvas_Chat.SetActive(true);
    }
	
	public void Next_Exit()
    {
		Canvas_Chat.SetActive(false);
    }
}
