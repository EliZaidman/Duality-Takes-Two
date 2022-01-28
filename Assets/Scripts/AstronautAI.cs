using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AstronautAI : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDeath;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            OnDeath.Invoke();
            Debug.Log("EnteredIntoInvoke");
        }
    }
}
