using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Home_Quiz : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Quiz_Canvas;
	
    public AudioClip[] allaudio;
    public Vocabulary[] vocabularies;
    public VocabularyNavigation vocabularyNavigation;
    public int vocabularynumber;
    public int[] randomArray;

	AudioSource audio;
    public GameObject Sound_Canvas;

    public AudioClip corr;
    public AudioClip fal;
    public AudioClip end;
    
    public int count = 0;
    public string nowword;
    public string ans;
    public int  i=0;
    public int flag = 0;
	
	private Home_QuizChange Home_QuizChange;
	
    void Awake()
    {
        vocabularyNavigation = this.transform.GetComponent<VocabularyNavigation>();
        //Quiz_Canvas = GameObject.Find("selectVocabulary");//改成在selectVocabulary尋找物件
        Home_QuizChange= GameObject.FindGameObjectWithTag("GameController").GetComponent<Home_QuizChange>();
    }




    void Start()
    {
        Home_QuizChange = this.GetComponent<Home_QuizChange>();
        audio = Home_QuizChange.Sound_Canvas.transform.GetChild(0).GetComponent<AudioSource>();
        /*vocabularyNavigation = this.GetComponent<VocabularyNavigation>();
        Sound_Canvas = home_QuizChange.Sound_Canvas;*/
        ramdom();
    }

    public void ramdom()
    {

        //resturant_Vocabularytest = this.GetComponent<Resturant_Vocabularytest>();

        vocabularynumber = vocabularyNavigation.vocabularies.Length;
        //vocabularynumber = 8;
        randomArray = new int[vocabularynumber];
        for (int k = 0; k < vocabularynumber; k++)
        {
            randomArray[k] = Random.Range(0, vocabularynumber);   //亂數產生，亂數產生的範圍是1~9

            for (int j = 0; j < k; j++)
            {
                while (randomArray[j] == randomArray[k])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                {
                    j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                    randomArray[k] = Random.Range(0, vocabularynumber);   //重新產生，存回陣列，亂數產生的範圍是1~9
                }
            }
        }

    }

	public void check() {
        
        if (i <=7)
        {
            Debug.Log("第" + (i+1) + "題");
            
            if (nowword == ans)
            {
                count++;
                flag = 1;
                //StartCoroutine(Audio());
                Debug.Log("正確,目前分數:" + count + ",正確答案:" + ans);
            }
            else
            {
                flag = 2;
                //StartCoroutine(Audio());
                Debug.Log("錯誤,目前分數:" + count + ",正確答案:" + ans);
            }
            i++;
            Test();
        }        
    }
	
    public void Test()
    {
        if (i <= 7)
        {
            ans = vocabularyNavigation.vocabularies[randomArray[i]].name;
            StartCoroutine(Audio());
        }
           
    }

    IEnumerator Audio()
    {   
        if (flag == 1) {
            Sound_Canvas.transform.GetChild(0).gameObject.GetComponent<AudioSource>().clip = corr;
            Sound_Canvas.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(corr.length);
            yield return new WaitForSeconds(0.3f);
        }
        else if (flag == 2)
        {
            Sound_Canvas.transform.GetChild(0).gameObject.GetComponent<AudioSource>().clip = fal;
            Sound_Canvas.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(fal.length);
            yield return new WaitForSeconds(0.3f);
        }
        flag = 0;
        for (int j = 0; j < 3; j++)
        {
            if (i <= 7)
            {
                audio.clip = vocabularyNavigation.vocabularies[randomArray[i]].Vocabularyaudio;
                Sound_Canvas.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(vocabularyNavigation.vocabularies[randomArray[j]].Vocabularyaudio.length);
                yield return new WaitForSeconds(0.3f);
                
            }
            else {
                yield break;
            }
        }
        StopCoroutine(Audio());
    }


    
}
