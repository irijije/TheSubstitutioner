using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Water : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
    public void Generate(Vector3 position)
    {
        transform.position = position + new Vector3(0, 0.2f, 0);
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
