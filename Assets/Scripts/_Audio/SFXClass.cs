using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
[System.Serializable]

public class SFXClass 
{
    public string sfxName;
    public int sfxID;
    [EventRef]public string path;
    public EventInstance _event;
}
