using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
public class SpaceObject : MonoBehaviour
{

    [SerializeField] private GameObject darknessObj , doubleDarknessObj, lightObj, doubleLightObj, defaultGameObj;
    private void Awake()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            var lightCheck = collision.collider.gameObject.GetComponent<LightCheck>();

            switch(lightCheck.lightConditions)
            {
                case (LightCheck.LightConditions.darkness):
                    darknessObj.SetActive(true);
                    doubleDarknessObj.SetActive(false);
                    lightObj.SetActive(false);
                    doubleLightObj.SetActive(false);
                    defaultGameObj.SetActive(false);
                    break;
                case (LightCheck.LightConditions.DoubleDarkness):
                    darknessObj.SetActive(false);
                    doubleDarknessObj.SetActive(true);
                    lightObj.SetActive(false);
                    doubleLightObj.SetActive(false);
                    defaultGameObj.SetActive(false);
                    break;
                case (LightCheck.LightConditions.doubleLight):
                    darknessObj.SetActive(false);
                    doubleDarknessObj.SetActive(false);
                    lightObj.SetActive(false);
                    doubleLightObj.SetActive(true);
                    defaultGameObj.SetActive(false);
                    break;
                case (LightCheck.LightConditions.light):
                    darknessObj.SetActive(false);
                    doubleDarknessObj.SetActive(false);
                    lightObj.SetActive(true);
                    doubleLightObj.SetActive(false);
                    defaultGameObj.SetActive(false);
                    break;
                default:
                    darknessObj.SetActive(false);
                    doubleDarknessObj.SetActive(false);
                    lightObj.SetActive(false);
                    doubleLightObj.SetActive(false);
                    defaultGameObj.SetActive(true);
                    break;
            }
        }
    }
}
