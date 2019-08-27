using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    
    Rigidbody rb;
    Animator animator;
    GameObject equipPoint;

    Vector3 dest;
    Vector3 movement;

    bool isMoving;
    public bool isHeavy;
    bool isWall;
    public bool isHave;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        equipPoint = GameObject.FindGameObjectWithTag("Equip");
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isWall = true;
    }

    private void FixedUpdate()
    {
        Run(dest);
        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        if (isMoving)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void Run(Vector3 dest)
    {
        if (dest != new Vector3(0f, 0f, 0f)) {
            Vector3 dir = dest - transform.position;
            Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);
            this.dest = dest;
            if (dirXZ.x * dirXZ.x + dir.z * dir.z <= 0.01 || isWall) {
                isMoving = false;
                this.dest = transform.position;
                isWall = false;
            }
            else {
                isMoving = true;

                Quaternion newRotation = Quaternion.LookRotation(dirXZ);
                rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotateSpeed * Time.deltaTime);
                movement.Set(dirXZ.x, 0, dirXZ.z);
                movement = movement.normalized * moveSpeed * Time.deltaTime;

                rb.MovePosition(transform.position + movement);
            }
        }
    }

    public void Swap(Vector3 position)
    {
            GameObject item = equipPoint.GetComponentInChildren<Rigidbody>().gameObject;
            equipPoint.transform.DetachChildren();

            item.transform.position = new Vector3(position.x, position.y + 0.2f, position.z);

            Collider[] itemColliders = item.GetComponents<Collider>();
            Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

            foreach (Collider itemCollider in itemColliders)
            {
                if (itemCollider is MeshCollider) {
                    itemCollider.isTrigger = false;
                }
            }

            itemRigidbody.isKinematic = false;
    }

    public void Discard()
    {
        GameObject item = equipPoint.GetComponentInChildren<Rigidbody>().gameObject;
        equipPoint.transform.DetachChildren();

        Collider[] itemColliders = item.GetComponents<Collider>();
        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

        foreach (Collider itemCollider in itemColliders)
        {
            if (itemCollider is MeshCollider)
            {
                itemCollider.isTrigger = false;
            }
        }

        itemRigidbody.isKinematic = false;
        isHave = false;
    }

    public void HeavySwap(Vector3 position)
    {
        GameObject heavyItem = GameObject.FindGameObjectWithTag("CurrentHeavy");

        heavyItem.transform.position = new Vector3(position.x, position.y + 0.2f, position.z);
        heavyItem.tag = "HeavyItem";

    }
}
