using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    
    GameObject player;
    GameObject equipPoint;
    Player playerLogic;

    bool isPlayerEnter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLogic = player.GetComponent<Player>();
        equipPoint = GameObject.FindGameObjectWithTag("Equip");
    }

    void Start () {
		
	}

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }

    public void Open()
    {
        if (SceneManager.Equals(SceneManager.GetActiveScene(), SceneManager.GetSceneByName("Room3")))
        {
            if (isPlayerEnter) {
                gameObject.SetActive(false);
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (!SceneManager.Equals(SceneManager.GetActiveScene(), SceneManager.GetSceneByName("Asile"))) {
            if (playerLogic.isHave) {
            
                GameObject item = equipPoint.GetComponentInChildren<Rigidbody>().gameObject;

                if (isPlayerEnter && item.name == "key")
                {
                    gameObject.SetActive(false);
                    if (SceneManager.Equals(SceneManager.GetActiveScene(), SceneManager.GetSceneByName("Tutorial"))) {
                        PlayerPrefs.SetInt("Room", 1);
                    }
                    else if (SceneManager.Equals(SceneManager.GetActiveScene(), SceneManager.GetSceneByName("Room1")))
                    {
                        PlayerPrefs.SetInt("Room", 2);
                    }
                    else if (SceneManager.Equals(SceneManager.GetActiveScene(), SceneManager.GetSceneByName("Room2")))
                    {
                        PlayerPrefs.SetInt("Room", 3);
                    }
                    SceneManager.LoadScene("Asile");
                    
                }
            }
        }
        else
        {
            if (isPlayerEnter) {
                int i = PlayerPrefs.GetInt("Room");
                gameObject.SetActive(false);
                SceneManager.LoadScene("Room" + i);
            }
        }
    }
}
