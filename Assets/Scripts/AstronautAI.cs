using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AstronautAI : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDeath;
    [SerializeField] private UnityEvent OnConsume;

    private void OnTriggerEnter(Collider other)
   {
        if (other.tag == "Obsticle")
        {
            SpaceObject spaceObject = other.gameObject.GetComponent<SpaceObject>();

            OnObstacleCollision(spaceObject);
        }else if (other.tag == "ObstacleChild")
        {
            SpaceObject spaceObject = other.gameObject.GetComponentInParent<SpaceObject>();

            OnObstacleCollision(spaceObject);
        }
        
    }


    private void OnObstacleCollision(SpaceObject spaceObject)
    {
        if (!spaceObject.hitProperties.doHitPlayer) return;

        switch (spaceObject.hitProperties.colState)
        {
            case SpaceObject.SpaceObjHitProperties.CollisionState.Hit:
                OnDeath.Invoke();
                break;
            case SpaceObject.SpaceObjHitProperties.CollisionState.Break:
                spaceObject.OnBreak.Invoke();
                break;
            case SpaceObject.SpaceObjHitProperties.CollisionState.Consumable:
                OnConsume.Invoke();
                Destroy(spaceObject.gameObject);
                break;
            default:
                break;
        }



    }


}
