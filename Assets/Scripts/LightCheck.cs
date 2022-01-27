using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheck : MonoBehaviour
{

    enum LightConditions
    {
        light,
        doubleLight,
        darkness,
        DoubleDarkness,
    }

    public bool hittingLight;
    public GameObject lightCheck;
    public int maxInten;
    public int minInten;

    
    public List<GameObject> meshList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (meshList.Count >= 2)
        {
            Debug.Log("Darkness And Light");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Darkness")
        {
            meshList.Add(other.gameObject.GetComponent<GameObject>());
        }
        if (other.gameObject.tag == "Light")
        {
            //Debug.Log("Inside Light");
            meshList.Add(other.gameObject.GetComponent<GameObject>());
        }
    }
    void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Darkness")
        {
            meshList.Remove(other.gameObject.GetComponent<GameObject>());
        }
        if (other.gameObject.tag == "Light")
        {
            //Debug.Log("Inside Light");
            meshList.Remove(other.gameObject.GetComponent<GameObject>());
        }
    }

}
