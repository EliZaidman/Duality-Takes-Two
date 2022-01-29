using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteFlyAway : MonoBehaviour
{
    public float moveSpeed;
    bool HitByLight;

    private GameObject chosenPath;

    private void Awake()
    {
        chosenPath = GameManager.Instance.targetPosition[Random.Range(0, 1)];
        Debug.Log(chosenPath);
    }
    void Update()
    {

        


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);

        }
    }
}
