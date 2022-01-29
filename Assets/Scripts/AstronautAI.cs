using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AstronautAI : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDeath;
    private const string CHICKEN_NAME = "";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            OnDeath.Invoke();
            Debug.Log("EnteredIntoInvoke");
            var sfx = collision.gameObject.GetComponent<SpaceObject>().collisionSfx;
            FMODUnity.RuntimeManager.PlayOneShot(sfx.path, transform.position);
        }
    }


}
