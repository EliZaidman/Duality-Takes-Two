using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    [SerializeField] private GameObject darknessObj , doubleDarknessObj, lightObj, doubleLightObj, defaultGameObj;

    [SerializeField] private LightCheck lightCheck;
    private SFXClass objStateSfx;
    public SFXClass collisionSfx;

    private void Awake()
    {
        collisionSfx = AudioManager.instance.SfxList.Find(name => collisionSfx.sfxName == "collision"+gameObject.name);
    }
    public void LightCheckTrigger()
    {

        //objStateSfx = AudioManager.instance.SfxList.Find(name => objStateSfx.sfxName == gameObject.name);
        switch (lightCheck.lightConditions)
        {
            case LightCheck.LightConditions.darkness:
                darknessObj.SetActive(true);
                doubleDarknessObj.SetActive(false);
                lightObj.SetActive(false);
                doubleLightObj.SetActive(false);
                defaultGameObj.SetActive(false);
                if(objStateSfx != null)
                AudioManager.PlayOneShot(objStateSfx.path, "LightDark", 2, transform.position);
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
                if (objStateSfx != null)
                    AudioManager.PlayOneShot(objStateSfx.path, "LightDark", 1, transform.position);
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
