using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloatingAstronaut : MonoBehaviour
{
    [SerializeField]private GameObject centerObject;
   
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    [SerializeField] Vector2 freezeDelayRange;
    [SerializeField] Vector2 movementTimeRange;

    void Start()
    {
        CatchStart();
        StartCoroutine(RandomDestCoru());
    }

    private void CatchStart()
    {
        _startPosition = transform.position;
    }
    
    private IEnumerator RandomDestCoru()
    {

        while (true)
        {
         yield return new WaitForSeconds(Random.Range(freezeDelayRange.x,freezeDelayRange.y));
         yield return StartCoroutine(MoveToPosition(PickrRandomVector3()));
            
        }
    }

    private IEnumerator MoveToPosition(Vector3 dest)
    {
        float t=0;
        CatchStart();
        float moveTime = Random.Range(movementTimeRange.x, movementTimeRange.y);
        while (t<1)
        {
            t += Time.deltaTime / moveTime;
            transform.position = Vector3.Lerp(_startPosition, dest, t);
            yield return null;
        }
        
    }
        
    private Vector3 PickrRandomVector3()
    {
        Vector3 value=Vector3.zero;

        Vector3 scale = centerObject.transform.localScale;
        Vector3 pos = centerObject.transform.position;

        value.x = Random.Range(-scale.x / 2, scale.x / 2);
        value.y = Random.Range(-scale.y / 2, scale.y / 2);

        return pos + value;
    }
    
        
   

}
