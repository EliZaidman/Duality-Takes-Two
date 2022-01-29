using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Set this value in the inspector

    
    public float moveSpeed;

    private GameObject chosenPath;

    public LightCheck _lightCheck;

    
    private void Awake()
    {
        chosenPath = GameManager.Instance.targetPosition[Random.Range(0, 4)];
        Debug.Log(chosenPath);
        _lightCheck = gameObject.GetComponent<LightCheck>();


    }
    void Update()
    {

        if (_lightCheck.lightConditions == LightCheck.LightConditions.light || _lightCheck.lightConditions == LightCheck.LightConditions.doubleLight)
        {
            moveAway();
        }
        else
        {
            moveInside();
        }

    }

    private void moveInside()
    {
        Vector3 directionToMove = chosenPath.transform.position - transform.position;


        directionToMove = directionToMove.normalized * Time.deltaTime * moveSpeed;


        transform.Translate(directionToMove);

        //float maxDistance = Vector3.Distance(transform.position, chosenPath.transform.position);
        //transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
    }

    private void moveAway()
    {
        Vector3 directionToMoveAway = _lightCheck.FindVectorPos();


        directionToMoveAway = directionToMoveAway.normalized * Time.deltaTime * moveSpeed * 25;

        transform.Translate(directionToMoveAway);
    }
}
