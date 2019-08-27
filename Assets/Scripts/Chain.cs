using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Break()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        Transform[] transform1 = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform trans in transform1)
        {
            if (trans.gameObject.name == "steel")
            {
                trans.gameObject.SetActive(false);
            }
        }
        Renderer[] renderer1 = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderer1)
        {
            rend.enabled = true;
        }
        Rigidbody[] rigidbody1 = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigid in rigidbody1)
        {
            rigid.useGravity = true;
        }
        Collider[] collider1 = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in collider1)
        {
            collider.isTrigger = false;
        }
    }
}
