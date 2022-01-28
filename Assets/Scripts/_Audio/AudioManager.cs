using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
public class AudioManager : MonoBehaviour
{
    [SerializeField] public List<SFXClass> SfxList = new List<SFXClass>();
    public const string LIGHT_DARK_PARAM_NAME = "LightDark";
    [Header("BGM")]
    public const string BGM_PARAM_NAME = "Intensity";
    private EventInstance bgmEvent;
    [EventRef]public string bgmRef;
    [SerializeField] private int bgmIntensity;
    [SerializeField] private int bgmIntensityRate;

    public static AudioManager instance;
    private void Awake()
    {
        bgmIntensity = 0;
        instance = this;
        bgmEvent = RuntimeManager.CreateInstance(bgmRef);
    }
    private void Start()
    {
        PlayBGM();
        InvokeRepeating("IncreaseIntensity", 0 ,bgmIntensityRate);
        PlayOneShot(SfxList[0].path, LIGHT_DARK_PARAM_NAME, 0, transform.position); //1,2   1,2
    }
    public static void PlayOneShot(string path, string parameterName, float parameterValue, Vector3 position = new Vector3())
    {
        var instance = RuntimeManager.CreateInstance(path);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(position));
        instance.setParameterByName(parameterName, parameterValue);
        instance.start();
        instance.release();
    }
    public void PlayOneShotByName(string sfxName)
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
    private void IncreaseIntensity()
    {
        if(bgmIntensity < 4)
        bgmParameterChange(BGM_PARAM_NAME, bgmIntensity++);
    }

}
/*    
 *                  private SFXClass sfxToPlay;
                    sfxToPlay = AudioManager.instance.SfxList.Find(name => sfxToPlay.sfxName == gameObject.name);
                    AudioManager.PlayOneShot(sfxToPlay.path, "LightDark", 2,transform.position);


    }*/