using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using UnityEngine.Events;
public class SpaceObjHitProperties
{
    public string name;
    public bool doHitPlayer;
    public enum CollisionState { Hit, Break, Consumable }
}
public class SpaceObject : MonoBehaviour
{
  

    [SerializeField] 
    private LightCheck lightCheck;
    public SFXClass objStateSfx;
    public SFXClass collisionSfx;
    internal SpaceObjHitProperties hitProperties = new SpaceObjHitProperties();
    [SerializeField]
    private StateProperties[] stateProperties;

    public UnityEvent OnBreak;
    public UnityEvent OnConsumed;

    public void DestroyObject()
    {
        Destroy(this);
    }
    private void OnValidate()
    {
        foreach(StateProperties found in stateProperties)
        {
           if(found!=null)
            found.stateName = found.lightCondition.ToString();

        }
    }
    private void Awake()
    {
        hitProperties.Init(gameObject.name, true, SpaceObjHitProperties.CollisionState.Hit);
        objStateSfx = AudioManager.instance.SfxList.Find(name => name.sfxName == gameObject.name);
        collisionSfx = AudioManager.instance.SfxList.Find(name => name.sfxName == "col"+gameObject.name);
    }
    
    public void LightCheckTrigger()
    {
        StateProperties state = SetObjState(lightCheck.lightConditions);
        hitProperties.ModularParamsInit(state.doHitPlayer, state.colState);
        if (objStateSfx != null)
        AudioManager.instance.PlayOneShot(objStateSfx.path, AudioManager.LIGHT_DARK_PARAM_NAME, state.stateFmodParamValue, transform.position);
   
    }
    private StateProperties SetObjState(LightCheck.LightConditions lightCondition)
    {
        StateProperties value = new StateProperties();
        foreach (var state in stateProperties)
        {
            if (state.lightCondition != lightCondition)
            {
                state.obj.SetActive(false);
            
            }
            else 
            {
                value = state;

                state.obj.SetActive(true);
            }
            
        }
        return value;
    }
    public class SpaceObjHitProperties
    {
        public string name;
        public bool doHitPlayer;
        public int stateFmodParamValue;
        public enum CollisionState { Hit, Break, Consumable }
        public CollisionState colState;
        public void Init(string _name , bool _doHit,CollisionState _state )
        {
            name = _name;
            doHitPlayer = _doHit;
            colState = _state;
        }
        public void ModularParamsInit(bool _doHit , CollisionState _state)
        {
            doHitPlayer = _doHit;
            colState = _state;
        }
        
    }
    [System.Serializable]
    public class StateProperties
    {
        public string stateName;
        [Header("States")]
        public GameObject obj;
        public LightCheck.LightConditions lightCondition;
        [Space]
        public bool doHitPlayer;
        [Space]
        public SpaceObjHitProperties.CollisionState colState;

        public int stateFmodParamValue;
        

    }
  
}
