using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GUISkin guiSkin;
        
    void Awake()
    {
        Time.timeScale = 1f;    
    }

    void Start () {
    }
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    void OnGUI()
    {
        GUI.skin = guiSkin;

    }

    public static void EndGame()
    {
        Time.timeScale = 0f;
    }
}
