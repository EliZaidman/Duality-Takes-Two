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


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("StoppingTrigger")) return;

        if (collision.collider == positiveCollider)
        {
            blockPositive = true;
        }

        if (collision.collider == negativeCollider)
        {
            blockNegative = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("StoppingTrigger")) return;

        if (collision.collider == positiveCollider)
        {
            blockPositive = false;
        }

        if (collision.collider == negativeCollider)
        {
            blockNegative = false;
        }
    }

   
}
