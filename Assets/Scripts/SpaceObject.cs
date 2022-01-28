using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    [SerializeField] private GameObject darknessObj , doubleDarknessObj, lightObj, doubleLightObj, defaultGameObj;

    [SerializeField] private LightCheck lightCheck;

    public void LightCheckTrigger()
    {
        switch (lightCheck.lightConditions)
        {
            case LightCheck.LightConditions.darkness:
                darknessObj.SetActive(true);
                doubleDarknessObj.SetActive(false);
                lightObj.SetActive(false);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                break;
            case LightCheck.LightConditions.DoubleDarkness:
                darknessObj.SetActive(false);
                doubleDarknessObj.SetActive(true);
                lightObj.SetActive(false);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                break;
            case LightCheck.LightConditions.doubleLight:
                darknessObj.SetActive(false);
                doubleDarknessObj.SetActive(false);
                lightObj.SetActive(false);
                doubleLightObj.SetActive(true);
                defaultGameObj.SetActive(false);
                break;
            case LightCheck.LightConditions.light:
                darknessObj.SetActive(false);
                doubleDarknessObj.SetActive(false);
                lightObj.SetActive(true);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                break;
            case LightCheck.LightConditions.Default:
                darknessObj.SetActive(false);
                doubleDarknessObj.SetActive(false);
                lightObj.SetActive(false);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(true);
                break;
        }
    }
}
