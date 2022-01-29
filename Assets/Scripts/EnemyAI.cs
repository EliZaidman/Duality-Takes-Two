using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Set this value in the inspector

    
    public float lightPushmoveSpeed;
    public float normalmoveSpeed;

    private GameObject chosenPath;

    public LightCheck _lightCheck;

    [SerializeField] bool ispushedFromLight;

    
    private void Awake()
    {
        chosenPath = GameManager.Instance.targetPosition[Random.Range(0, 4)];
        Debug.Log(chosenPath);
        _lightCheck = gameObject.GetComponent<LightCheck>();

    }
    void Update()
    {
        if (ispushedFromLight)
        {
            if (_lightCheck.lightConditions == LightCheck.LightConditions.light || _lightCheck.lightConditions == LightCheck.LightConditions.doubleLight)
            {
                moveAway();
            }
            else
            {
                moveInside();
            }
        }else moveInside();

    }

    private void moveInside()
    {
        Vector3 directionToMove = chosenPath.transform.position - transform.position;


        directionToMove = directionToMove.normalized * Time.deltaTime * normalmoveSpeed;


        transform.Translate(directionToMove);

        //float maxDistance = Vector3.Distance(transform.position, chosenPath.transform.position);
        //transform.position = transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
    }

    private void moveAway()
    {
    //    Vector3 directionToMoveAway = _lightCheck.FindVectorPos();

    //    directionToMoveAway = directionToMoveAway.normalized * Time.deltaTime * lightPushmoveSpeed;
    //    directionToMoveAway.z = 0;

        transform.Translate(transform.right*-1*Time.deltaTime*lightPushmoveSpeed);
    }
}
