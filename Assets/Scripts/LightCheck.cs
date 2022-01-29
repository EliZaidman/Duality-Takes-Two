using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightCheck : MonoBehaviour
{
    //#region Singleton
    //private static LightCheck _instance;
    //public static LightCheck Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //            Debug.Log("LightCheck not loaded properly");

    //        return _instance;
    //    }
    //}

    //private LightCheck()
    //{

    //}
    //#endregion
    public enum LightConditions
    {
        Default,
        light,
        doubleLight,
        darkness,
        DoubleDarkness,
    }
    public LightConditions lightConditions;

    public List<GameObject> lightMeshList = new List<GameObject>();
    public List<GameObject> darkMeshList = new List<GameObject>();

    public GameObject SideShadow;
    public GameObject SideLight;
    public GameObject topShadow;
    public GameObject topLight;

    [SerializeField] private UnityEvent OnSync;

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "TopShadow")
        {
            topShadow = other.gameObject;
            darkMeshList.Add(other.gameObject);
            Sync();
        }
        if (other.gameObject.tag == "SideShadow")
        {
            SideShadow = other.gameObject;
            //Debug.Log("Inside Light");
            darkMeshList.Add(other.gameObject);
            Sync();
        }
        if (other.gameObject.tag == "TopLight")
        {
            topLight = other.gameObject;
            lightMeshList.Add(other.gameObject);

            Sync();
        }
        if (other.gameObject.tag == "SideLight")
        {
            SideLight = other.gameObject;
            //Debug.Log("Inside Light");
            lightMeshList.Add(other.gameObject);
            Sync();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TopShadow")
        {
            topShadow = null;
            darkMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
        if (other.gameObject.tag == "SideShadow")
        {
            SideShadow = null;
            //Debug.Log("Inside Light");
            darkMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
        if (other.gameObject.tag == "TopLight")
        {
            topLight = null;
            lightMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
        if (other.gameObject.tag == "SideLight")
        {
            SideLight = null;
            //Debug.Log("Inside Light");
            lightMeshList.Remove(other.gameObject.GetComponent<GameObject>());
            Sync();
        }
    }
    private bool isDoubleFromBouth()
    {
        return (SideLight && SideShadow && topLight && topShadow);
    }
    private bool isLightedBySide()
    {
        return (SideLight && !SideShadow);
    }
    private bool isLightedByTop()
    {
        return (topLight && !topShadow);
    }

    private bool isShadowedByTop()
    {
        return topShadow;
    }
    private bool isShadowedBySide()
    {

        return SideShadow;
    }
    private bool isDefault()
    {
        return (!SideShadow && !topShadow && !SideLight && !topLight);
    }

    public void Sync()
    {
        if (isDefault())
        {
            lightConditions = LightConditions.Default;
            OnSync.Invoke();
            return;
        }

        //LIGHT
        if (isLightedBySide() && isLightedByTop())
        {
            Debug.Log("DoubleLight");
            lightConditions = LightConditions.doubleLight;
            OnSync.Invoke();
            return;
        }

        if (isLightedBySide() || isLightedByTop())
        {
            Debug.Log("SingleLight");
            lightConditions = LightConditions.light;
            OnSync.Invoke();
            return;
        }
        //LIGHT

        ////DARKNESS AND LIGHT
        //if (!isLightedBySide() && !isLightedByTop())
        //{
        //    Debug.Log("");
        //    lightConditions = LightConditions.darkness;
        //    OnSync.Invoke();
        //    return;
        //}

        //DARKNESS
        if (isShadowedBySide() && isShadowedByTop())
        {
            Debug.Log("DoubleDarkness");
            lightConditions = LightConditions.DoubleDarkness;
            OnSync.Invoke();
            return;
        }

        if (isShadowedBySide() || isShadowedByTop())
        {
            Debug.Log("Darkness");
            lightConditions = LightConditions.darkness;
            OnSync.Invoke();
            return;
        }




    }

    public Vector3 FindVectorPos()
    {
        Vector3 value = Vector3.zero;

        foreach (GameObject found in lightMeshList)
        {
            if (found != null)
            value += found.transform.position - transform.position;
        }

        return -(value / lightMeshList.Count).normalized;
    }
}
