using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microphone_Control : MonoBehaviour
{

    bool micConnected = false;
    int minFreq, maxFreq;

    AudioSource goAudioSource;

    void Start()
    {
        if (Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("沒有麥克風連線");
        }
        else
        {
            micConnected = true;
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            if (minFreq == 0 && minFreq == 0)
            {
                maxFreq = 44100;

            }

            goAudioSource = GetComponent<AudioSource>();

        }
    }


    void OnGUI()
    {

        if (micConnected)
        {
            if (!Microphone.IsRecording(null))
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Record"))
                {
                    goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);
                }

            }
            else
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Stop and Play"))
                {
                    Microphone.End(null);

                    SaveWav.Save("myWave", goAudioSource.clip);


                    goAudioSource.Play();
                }
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 200, 50), "Microphone is using....");
            }



     


        }
    }
}
