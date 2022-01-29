using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPass : MonoBehaviour
{
    LightCheck light;
    void Start()
    {
        light= GetComponentInParent<LightCheck>();
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "TopShadow")
        {
            light.topShadow = other.gameObject;
            light.darkMeshList.Add(other.gameObject);
            light.Sync();
        }
        if (other.gameObject.tag == "SideShadow")
        {
            light.SideShadow = other.gameObject;
            //Debug.Log("Inside Light");
            light.darkMeshList.Add(other.gameObject);
            light.Sync();
        }
        if (other.gameObject.tag == "TopLight")
        {
            light.topLight = other.gameObject;
            light.lightMeshList.Add(other.gameObject);

            light.Sync();
        }
        if (other.gameObject.tag == "SideLight")
        {
            light.SideLight = other.gameObject;
            //Debug.Log("Inside Light");
            light.lightMeshList.Add(other.gameObject);
            light.Sync();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TopShadow")
        {
            light.topShadow = null;
            light.darkMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
        if (other.gameObject.tag == "SideShadow")
        {
            light.SideShadow = null;
            //Debug.Log("Inside Light");
            light.darkMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
        if (other.gameObject.tag == "TopLight")
        {
            light.topLight = null;
            light.lightMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
        if (other.gameObject.tag == "SideLight")
        {
            light.SideLight = null;
            //Debug.Log("Inside Light");
            light.lightMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
    }
}
