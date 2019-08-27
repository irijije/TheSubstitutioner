using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HeavyItem : MonoBehaviour
{

    Player playerLogic;
    GameObject player;

    public bool isPlayerEnter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLogic = player.GetComponent<Player>();
    }

    void Start()
    {
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
            playerLogic.isHave = false;
            playerLogic.isHeavy = false;
        }
    }

    public void Touch()
    {
        if (isPlayerEnter && !playerLogic.isHave)
        {
            gameObject.tag = "CurrentHeavy";
            playerLogic.isHeavy = true;
            playerLogic.isHave = true;
        }
    }

    public void Swap()
    {
        GameObject currentHeavy = GameObject.FindGameObjectWithTag("CurrentHeavy");
        Vector3 dest = currentHeavy.transform.position;
        Collider[] itemColliders = GetComponents<Collider>();
        Rigidbody itemRigidbody = GetComponent<Rigidbody>();

        foreach (Collider itemCollider in itemColliders)
        {
            if (itemCollider is MeshCollider)
            {
                itemCollider.isTrigger = true;
            }
        }

        itemRigidbody.isKinematic = true;
        playerLogic.HeavySwap(transform.position);
        transform.position = dest;

        
        foreach (Collider itemCollider in itemColliders)
        {
            if (itemCollider is MeshCollider)
            {
                itemCollider.isTrigger = false;
            }
        }

        itemRigidbody.isKinematic = false;
    }
    public void WaterSwap()
    {
        GameObject water = GameObject.FindGameObjectWithTag("Water");
        Water waterLogic = water.GetComponent<Water>();
        Collider[] itemColliders = GetComponents<Collider>();
        Rigidbody itemRigidbody = GetComponent<Rigidbody>();

        foreach (Collider itemCollider in itemColliders)
        {
            if (itemCollider is MeshCollider)
            {
                itemCollider.isTrigger = true;
            }
        }

        itemRigidbody.isKinematic = true;
        waterLogic.Generate(transform.position);
        transform.position = player.transform.position + new Vector3(0, 0.5f, -1f);

        foreach (Collider itemCollider in itemColliders)
        {
            if (itemCollider is MeshCollider)
            {
                itemCollider.isTrigger = false;
            }
        }

        itemRigidbody.isKinematic = false;
    }
}
