using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPass : MonoBehaviour
{
    List<GameObject> intersectingObjects=new List<GameObject>();
    LightCheck light;

    public bool NotChangeAbleAfterLight;
    bool isstuckOnState = false;
    void Start()
    {
        light= GetComponentInParent<LightCheck>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (isstuckOnState) return;
        if (collision.gameObject.tag == "TopShadow")
            {
                light.topShadow = collision.gameObject;
                light.darkMeshList.Add(collision.gameObject);
                light.Sync();
            }
            if (collision.gameObject.tag == "SideShadow")
            {
                light.SideShadow = collision.gameObject;
                //Debug.Log("Inside Light");
                light.darkMeshList.Add(collision.gameObject);
                light.Sync();
            }
            if (collision.gameObject.tag == "TopLight")
            {
                light.topLight = collision.gameObject;
                light.lightMeshList.Add(collision.gameObject);
            if (NotChangeAbleAfterLight)
            {
                isstuckOnState = true;
            }
            light.Sync();
            }
        if (collision.gameObject.tag == "SideLight")
        {
            light.SideLight = collision.gameObject;
            //Debug.Log("Inside Light");
            light.lightMeshList.Add(collision.gameObject);
            if (NotChangeAbleAfterLight)
            {
                isstuckOnState = true;
            }
            light.Sync();
        }
        

    }
    private void OnTriggerExit(Collider collision)
    {
        if (isstuckOnState) return;
        if (collision.gameObject.tag == "TopShadow")
        {
            light.topShadow = null;
            light.darkMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
        if (collision.gameObject.tag == "SideShadow")
        {
            light.SideShadow = null;
            //Debug.Log("Inside Light");
            light.darkMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
        if (collision.gameObject.tag == "TopLight")
        {
            light.topLight = null;
            light.lightMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
        if (collision.gameObject.tag == "SideLight")
        {
            light.SideLight = null;
            //Debug.Log("Inside Light");
            light.lightMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
            light.Sync();
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!light.lightMeshList.Contains(collision.gameObject) && !light.darkMeshList.Contains(collision.gameObject))
    //    {

    //        if (collision.gameObject.tag == "TopShadow")
    //        {
    //            light.topShadow = collision.gameObject;
    //            light.darkMeshList.Add(collision.gameObject);
    //            light.Sync();
    //        }
    //        if (collision.gameObject.tag == "SideShadow")
    //        {
    //            light.SideShadow = collision.gameObject;
    //            //Debug.Log("Inside Light");
    //            light.darkMeshList.Add(collision.gameObject);
    //            light.Sync();
    //        }
    //        if (collision.gameObject.tag == "TopLight")
    //        {
    //            light.topLight = collision.gameObject;
    //            light.lightMeshList.Add(collision.gameObject);

    //            light.Sync();
    //        }
    //        if (collision.gameObject.tag == "SideLight")
    //        {
    //            light.SideLight = collision.gameObject;
    //            //Debug.Log("Inside Light");
    //            light.lightMeshList.Add(collision.gameObject);
    //            light.Sync();
    //        }
    //    }
        
    //}
    //private void OnCollisionExit(Collision collision)
    //{
        
    //    if (collision.gameObject.tag == "TopShadow")
    //    {
    //        light.topShadow = null;
    //        light.darkMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
    //        light.Sync();
    //    }
    //    if (collision.gameObject.tag == "SideShadow")
    //    {
    //        light.SideShadow = null;
    //        //Debug.Log("Inside Light");
    //        light.darkMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
    //        light.Sync();
    //    }
    //    if (collision.gameObject.tag == "TopLight")
    //    {
    //        light.topLight = null;
    //        light.lightMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
    //        light.Sync();
    //    }
    //    if (collision.gameObject.tag == "SideLight")
    //    {
    //        light.SideLight = null;
    //        //Debug.Log("Inside Light");
    //        light.lightMeshList.Remove(collision.gameObject.GetComponent<GameObject>());
    //        light.Sync();
    //    }
    //}
    
}
