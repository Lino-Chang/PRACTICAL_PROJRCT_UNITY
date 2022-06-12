using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_QuizChange : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject Canvas_CP;
	public GameObject Canvas_QI;
	public GameObject Canvas_Introduction;
    public GameObject Canvas_Detail;

    public GameObject Canvas_Score;
	
	public GameObject vocabularys;
	public GameObject Sound_Canvas;
	
    private Home_Quiz Home_Quiz;
	public int mod_flag = 0;    //模式旗標，預設為練習模式(0)；而測驗模式(1)
	
	public Text text_vocabulary;
	
	
	private void Awake()
    {
		Home_Quiz = GameObject.FindGameObjectWithTag("GameController").GetComponent<Home_Quiz>();


	}
    
	
	public void Chat()
    {
		Canvas_CP.SetActive(true);
    }
	
	public void Train()	//詞彙練習
    {
		mod_flag=0;
		Canvas_CP.SetActive(false);
		Canvas_Introduction.SetActive(true);
    }
	
	public void Quiz()	//詞彙測驗
    {
		mod_flag=1;
		Canvas_CP.SetActive(false);
		Canvas_QI.SetActive(true);
    }
	
	public void Exit_Train()	//詞彙練習的回首頁喔
    {
		Canvas_Introduction.SetActive(false);
		Canvas_CP.SetActive(true);
    }
	
	public void Exit_Quiz()	//這是詞彙測驗的叉叉喔
	{
		Canvas_QI.SetActive(false);
		Canvas_CP.SetActive(true);
	}
	
	public void Exit_Chat()	//回主場景
	{
		Canvas_CP.SetActive(false);
	}
	
	public void Exit_Score()	//這是記分板的叉叉喔
	{
		Canvas_Score.SetActive(false);
	}
	
	public void Exit_ScoreClose()
	{
		Canvas_Score.SetActive(false);
		Canvas_CP.SetActive(true);
	}

    public void Start_Learn()    //開始學習
    {
        Canvas_Introduction.SetActive(false);
    }

    public void Exit_Learn()    //結束學習
    {
        Canvas_Detail.SetActive(false);
    }

    public void Learn_Back()	//學習的的回首頁喔
    {
        Canvas_Detail.SetActive(false);
        Canvas_CP.SetActive(true);
    }

    public void Start_Quiz() //開始測驗
	{
		Canvas_QI.SetActive(false);
		vocabularys.SetActive(true);
		Sound_Canvas.SetActive(true);
		
        Home_Quiz.count = 0;   //計分
		Home_Quiz.i = 0;   //題數
        Home_Quiz.Test();
		
	}
	
	public void final()
    {
        Canvas_Score.SetActive(true);
        text_vocabulary = Canvas_Score.transform.GetChild(1).GetComponent<Text>();
        text_vocabulary.text = "本次測驗總分為　" + Home_Quiz.count.ToString();
    }
    
}
