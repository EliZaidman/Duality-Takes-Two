using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    [SerializeField] private GameObject doubleLightObj;
    [SerializeField] private GameObject lightObj;
    [SerializeField] private GameObject defaultGameObj;
    [SerializeField] private GameObject darknessObj;
    [SerializeField] private GameObject doubleDarknessObj;
    [SerializeField] private LightCheck lightCheck;

    public void LightCheckTrigger()
    {
        switch (lightCheck.lightConditions)
        {
            case LightCheck.LightConditions.darkness:
                doubleDarknessObj.SetActive(false);
                lightObj.SetActive(false);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                darknessObj.SetActive(true);
                break;
            case LightCheck.LightConditions.DoubleDarkness:
                darknessObj.SetActive(false);
                lightObj.SetActive(false);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                doubleDarknessObj.SetActive(true);
                break;
            case LightCheck.LightConditions.doubleLight:
                darknessObj.SetActive(false);
                doubleDarknessObj.SetActive(false);
                lightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                doubleLightObj.SetActive(true);
                break;
            case LightCheck.LightConditions.light:
                darknessObj.SetActive(false);
                doubleDarknessObj.SetActive(false);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                lightObj.SetActive(true);
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
