using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
public class AudioManager : MonoBehaviour
{
    [SerializeField]public  List<SFXClass> SfxList = new List<SFXClass>();
    private EventInstance bgmEvent;
    [EventRef]public string bgmRef;
    public const string BGM_PARAMETER_NAME = "BGMintensity";
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
        bgmEvent = RuntimeManager.CreateInstance(bgmRef);
    }
    private void Start()
    {
        PlayBGM();
        PlayOneShot("SpaceWhoosh");
    }

    public void PlayOneShot(string sfxName)
    {
        var sfxToPlay = SfxList.Find(name => name.sfxName == sfxName);
        RuntimeManager.PlayOneShot(sfxToPlay.path);
    } 
    public void PlayBGM() => bgmEvent.start();
    public void StopBGM()
    {
        bgmEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bgmEvent.release();
 
    }
    public void bgmParameterChange(string parameterName,int parameterValue)
    {
        bgmEvent.setParameterByName(parameterName, parameterValue, true);
    }





}
