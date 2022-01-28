using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightCheck : MonoBehaviour
{

    public enum LightConditions
    {
        light,
        doubleLight,
        darkness,
        DoubleDarkness,
    }
    public LightConditions lightConditions;

    public List<GameObject> lightMeshList = new List<GameObject>();
    public List<GameObject> darkMeshList = new List<GameObject>();

    [SerializeField] private UnityEvent OnSync;

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Darkness")
        {
            darkMeshList.Add(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
        if (other.gameObject.tag == "Light")
        {
            //Debug.Log("Inside Light");
            lightMeshList.Add(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
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

        if (darkMeshList.Count == 0 && lightMeshList.Count == 0)
        {
            Debug.Log("Void");
        }

        OnSync.Invoke();
    }
}
