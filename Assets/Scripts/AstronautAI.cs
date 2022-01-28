using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AstronautAI : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDeath;
    [SerializeField] private UnityEvent OnWin;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            OnDeath.Invoke();
            Debug.Log("");
        } 

        if (collision.gameObject.tag == "Moon")
        {
            OnWin.Invoke();
            Debug.Log("");
        }
    }
}
