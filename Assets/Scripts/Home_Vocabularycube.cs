using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Vocabularycube : MonoBehaviour
{
    // Start is called before the first frame update
	
	public string thisvocabularyname;
    //private bool istouch = false;
    [SerializeField]private Material basic_material;
	private Home_QuizChange Home_QuizChange;
	
	private Home_Quiz Home_Quiz;
	public int mod_flag;
	private Vocabulary thisvocabulary;
	AudioSource audio;
	private VocabularyNavigation vocabularyNavigation;
    public Vocabulary[] vocabularies;

   
    private GameObject Canvas_Detail;
    private Home_display Home_display;

    private void Awake()
    {

        thisvocabularyname = this.transform.name;
        Home_QuizChange = GameObject.FindGameObjectWithTag("GameController").GetComponent<Home_QuizChange>();
        Home_Quiz = GameObject.FindGameObjectWithTag("GameController").GetComponent<Home_Quiz>();
        Home_display = GameObject.FindGameObjectWithTag("GameController").GetComponent<Home_display>();
        vocabularyNavigation = GameObject.FindGameObjectWithTag("GameController").GetComponent<VocabularyNavigation>();

    }


    void Start()
	{
		audio =Home_QuizChange.Sound_Canvas.transform.GetChild(0).GetComponent<AudioSource>();

        //audio = Home_QuizChange.Sound_Canvas.transform.GetChild(0).GetComponent<AudioSource>();
        Canvas_Detail = Home_QuizChange.Canvas_Detail;

        Home_display = Canvas_Detail.GetComponent<Home_display>();

        Canvas_Detail.SetActive(false);
        for (int i = 0; i < vocabularyNavigation.vocabularies.Length; i++)
        {

            if (thisvocabularyname == vocabularyNavigation.vocabularies[i].name)
            {

                thisvocabulary = vocabularyNavigation.vocabularies[i];

            }
        }
    }
	
	
	public void Entercube()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.red;

    }
    public void Exitcube()
    {
        this.GetComponent<MeshRenderer>().material = basic_material;
    }

    public void Clickcube()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
        
		mod_flag = Home_QuizChange.mod_flag;
        Debug.LogWarning(mod_flag);

        if (mod_flag == 0)
        {
            Canvas_Detail.SetActive(true);

            Home_display.vocabulary = thisvocabulary;

            Home_display.Clickvocabulary();
        }
        else if (mod_flag == 1) {
           // Sound_Canvas.SetActive(true);
            Home_Quiz.nowword = thisvocabularyname;
            Home_Quiz.check();
            if (Home_Quiz.i >= 8)
            {
                //Debug.Log(Home_Quiz.i);
                audio.clip = Home_Quiz.end;
                audio.Play();
                Home_QuizChange.final();
            }
        }

    }
}
