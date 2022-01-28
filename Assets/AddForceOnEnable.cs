using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnEnable : MonoBehaviour
{
    List<Rigidbody> m_bodies;
    [SerializeField] private float force = 5;
    [SerializeField] private float radius = 5;
    [SerializeField] private float distance = 1;
    [SerializeField] private float TTL = 3;

    [SerializeField] private List<mesh>
    private void OnEnable()
    {
        foreach (Rigidbody item in GetComponentsInChildren<Rigidbody>())
        {
            item.position = new Vector3(Random.RandomRange(-distance, distance), Random.RandomRange(-distance, distance), Random.RandomRange(-distance, distance));
            item.AddExplosionForce(force, transform.position, radius, 1, ForceMode.Impulse);
        }
        Invoke("Destroy", TTL);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

}
