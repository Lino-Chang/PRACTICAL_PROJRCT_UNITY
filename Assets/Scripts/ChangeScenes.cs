
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SceneMain()
    {
        SceneManager.LoadScene(0);
    }

    public void SceneHome()
    {
        SceneManager.LoadScene(1);
    }

    public void SceneTheater()
    {
        SceneManager.LoadScene(2);
    }







}
