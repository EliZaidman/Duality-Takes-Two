using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjects : MonoBehaviour
{
    public enum ObjectType { Asteroid , Sattelite}
    [SerializeField] private ObjectType objType;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // Get lightCheck enum states light/dark state.
            //switch between player states
            //Each player states function
        }
    }
}
