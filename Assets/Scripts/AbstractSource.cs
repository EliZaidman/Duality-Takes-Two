using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractSource : MonoBehaviour
{

    [SerializeField] Collider positiveCollider;
    [SerializeField] Collider negativeCollider;
    [SerializeField] private float movementSpeed;
    [SerializeField] Vector3 movementAxis;


    private bool blockPositive;
    private bool blockNegative;
    public void MoveSource(float movementFactor)
    {
        if (blockPositive && movementFactor > 0) { movementFactor = 0; }
        if (blockNegative && movementFactor < 0) { movementFactor = 0; }
        transform.Translate(((movementAxis*movementFactor)*movementSpeed)*Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == positiveCollider)
        {
            blockPositive = true;
        }

        if (other == negativeCollider)
        {
            blockNegative = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == positiveCollider)
        {
            blockPositive = false;
        }

        if (other == negativeCollider)
        {
            blockNegative = false;
        }
    }

}
