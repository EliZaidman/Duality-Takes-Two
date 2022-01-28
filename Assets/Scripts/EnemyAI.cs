using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Set this value in the inspector

    
    public float moveSpeed;

    private GameObject chosenPath;

    private void Awake()
    {
        chosenPath = GameManager.Instance.targetPosition[Random.Range(0, 4)];
        Debug.Log(chosenPath);
    }
    void Update()
    {

        Vector3 directionToMove = chosenPath.transform.position - transform.position;


        directionToMove = directionToMove.normalized * Time.deltaTime * moveSpeed;

        
        float maxDistance = Vector3.Distance(transform.position, chosenPath.transform.position);
        transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
            
        }
    }
}
