using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObject : MonoBehaviour {

    public Vector2 pos;
    public Vector3 movePos;

    GameObject player;
    GameObject mainCamera;
    Player playerLogic;
    MainCamera mainCameraLogic;
    Item itemLogic;
    HeavyItem heavyItemLogic;
    Door doorLogic;
    Jail jailLogic;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLogic = player.GetComponent<Player>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCameraLogic = mainCamera.GetComponent<MainCamera>();
    }

    void Start () {

    }

    void Click()
    {
        if (Input.GetMouseButtonUp(0) && !mainCameraLogic.isCamera)
        {
            RaycastHit hit;
            GameObject go;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
          
            if (hit.collider != null && hit.collider.gameObject.tag == "Ground" && !mainCameraLogic.isCamera)
            {
                playerLogic.Run(hit.point);
            }
            else if (hit.collider != null)
            {
                go = hit.collider.gameObject;
                pos = Camera.main.WorldToScreenPoint(go.transform.position);
                if (go.tag == "Door")
                {
                    doorLogic = go.GetComponent<Door>();
                    doorLogic.Open();
                }
                else if (go.tag == "Item")
                {
                    itemLogic = go.GetComponent<Item>();
                    if (playerLogic.isHave)
                    {
                        GameObject equipPoint = GameObject.FindGameObjectWithTag("Equip");
                        GameObject haveItem = equipPoint.GetComponentInChildren<Rigidbody>().gameObject;

                        if (GameObject.Equals(haveItem, go))
                        {
                            playerLogic.Discard();
                        }
                        else if (haveItem.GetComponent<Rigidbody>().mass == go.GetComponent<Rigidbody>().mass)
                        {
                            itemLogic.Swap();
                        }
                    }
                    else
                    {
                        itemLogic.PickUp();
                    }
                }
                else if (go.tag == "Lock")
                {
                    jailLogic = go.GetComponent<Jail>();
                    jailLogic.Open();
                }
                else if (go.tag == "HeavyItem" || go.tag == "CurrentHeavy")
                {
                    heavyItemLogic = go.GetComponent<HeavyItem>();
                    if (playerLogic.isHave && playerLogic.isHeavy)
                    {
                        heavyItemLogic.Swap();
                    }
                    else if (!playerLogic.isHave) {
                        if (heavyItemLogic.isPlayerEnter) {
                            heavyItemLogic.Touch();
                        }
                        else if (SceneManager.GetActiveScene().name == "Room3")
                        {
                            heavyItemLogic.WaterSwap();
                      
                        }
                    }
                }
                else if (go.tag == "Chain" && playerLogic.isHave)
                {
                    GameObject equipPoint = GameObject.FindGameObjectWithTag("Equip");
                    GameObject haveItem = equipPoint.GetComponentInChildren<Rigidbody>().gameObject;
                    if (haveItem.name == "chain1") {
                        Chain chainLogic = go.GetComponent<Chain>();
                        chainLogic.Break();
                    }
                }
            }
        }
    }

    void Update () {
        Click();
    }
}
