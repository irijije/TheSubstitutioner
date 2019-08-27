using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour {

    GameObject player;
    Player playerLogic;
    GameObject steel;
 
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLogic = player.GetComponent<Player>();
        steel = GameObject.FindGameObjectWithTag("Jail");
	}
	
	void Update () {
        Catch();
	}

    void Catch()
    {
        if (player.transform.position.x < 1 && player.transform.position.x > -1 && player.transform.position.y < 1 && player.transform.position.y > -1 && transform.position.y > 0.1) {
            Rigidbody rb = steel.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }

    public void Open()
    {
        if (playerLogic.isHave)
        {
            GameObject equipPoint = GameObject.FindGameObjectWithTag("Equip");
            GameObject item = equipPoint.GetComponentInChildren<Rigidbody>().gameObject;
            if (item.name == "key_gray" && transform.position.y < 8.8)
            {
                steel.SetActive(false);
            }
        }
    }
}
