using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheck : MonoBehaviour
{

    public enum LightConditions
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


    public List<GameObject> lightMeshList = new List<GameObject>();
    public List<GameObject> darkMeshList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Darkness")
        {
            lightMeshList.Add(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
        if (other.gameObject.tag == "Light")
        {
            //Debug.Log("Inside Light");
            darkMeshList.Add(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
    }
    void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Darkness")
        {
            darkMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
        if (other.gameObject.tag == "Light")
        {
            //Debug.Log("Inside Light");
            lightMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
    }

    private void Sync()
    {
        //LIGHT
        if (lightMeshList.Count >= 2 && darkMeshList.Count <= 0)
        {
            Debug.Log("EXTRA LIGHTTTT");
        }

        if (lightMeshList.Count == 1 && darkMeshList.Count <= 0)
        {
            Debug.Log("Inside Light");
        }
        //LIGHT

        //DARKNESS AND LIGHT
        if (darkMeshList.Count == 1 && darkMeshList.Count == 1)
        {
            Debug.Log("Inside Darkness AND Light");
        }

        if (darkMeshList.Count >= 2 && darkMeshList.Count >= 2)
        {
            Debug.Log("EXTRA DARKNESSS AND EXTRA LIGHTTTT");
        }
        //DARKNESS AND LIGHT

        //DARKNESS
        if (darkMeshList.Count >= 2 && lightMeshList.Count <= 0)
        {
            Debug.Log("EXTRA DARKNESSS");
        }

        if (darkMeshList.Count == 1 && lightMeshList.Count == 0)
        {
            Debug.Log("Inside Darkness");
        }
    }
}
