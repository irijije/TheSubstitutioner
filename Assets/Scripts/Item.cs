using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Item : MonoBehaviour {

    Player playerLogic;
    GameObject player;
    GameObject equipPoint;

    bool isPlayerEnter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        equipPoint = GameObject.FindGameObjectWithTag("Equip");
        playerLogic = player.GetComponent<Player>();
    }

    void Start () {
	}
	
	void Update () {
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

    public void PickUp()
    {
        if (isPlayerEnter)
        {
            Collider[] itemColliders = GetComponents<Collider>();
            Rigidbody itemRigidbody = GetComponent<Rigidbody>();

            foreach (Collider itemCollider in itemColliders)
            {
                if (itemCollider is MeshCollider) {
                    itemCollider.isTrigger = true;
                }
            }

            itemRigidbody.isKinematic = true;

            transform.SetParent(equipPoint.transform);
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);

            playerLogic.isHave = true;
        }
    }

    public void Swap()
    { 
            Collider[] itemColliders = GetComponents<Collider>();
            Rigidbody itemRigidbody = GetComponent<Rigidbody>();
            Transform transform1 = GetComponent<Transform>();

            foreach (Collider itemCollider in itemColliders)
            {
                if (itemCollider is MeshCollider) {
                    itemCollider.isTrigger = true;
                }
            }

            itemRigidbody.isKinematic = true;

            playerLogic.Swap(transform1.position);

            transform.SetParent(equipPoint.transform);
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);
    
            playerLogic.isHave = true;
    }
}
