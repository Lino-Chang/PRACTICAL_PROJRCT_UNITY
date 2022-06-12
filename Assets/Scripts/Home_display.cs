using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_display : MonoBehaviour
{
    //private GameObject vocabularys;
    public Vocabulary vocabulary;

    private GameObject Canvas_Detail;

    private AudioSource audio_vocabulary;
    private Image img_vocabulary;
    private Text text_vocabulary;

       
    private void Awake()
    {
        Canvas_Detail = GameObject.Find("Canvas_Detail");
        audio_vocabulary = Canvas_Detail.transform.GetChild(6).GetComponent<AudioSource>();
        img_vocabulary = Canvas_Detail.transform.GetChild(4).GetComponent<Image>();
        text_vocabulary = Canvas_Detail.transform.GetChild(1).GetComponent<Text>();
        
    }

    public  void Clickvocabulary()
    {
        Debug.LogWarning(vocabulary);        
        audio_vocabulary.clip = vocabulary.Vocabularyaudio;
        text_vocabulary.text = vocabulary.vocabularyname;
        img_vocabulary.sprite = vocabulary.Vocabularysprite;

    }

    public void Closevocabularydisplay()
    {
        Canvas_Detail.SetActive(false);
    }
}
