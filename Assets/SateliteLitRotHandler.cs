using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteLitRotHandler : MonoBehaviour
{
    [SerializeField]private GameObject m_litmodel;
    [SerializeField] private GameObject m_unlitmodel;
    [SerializeField] private float minRotSpeed = 15f;
    [SerializeField] private float maxRotSpeed = 25f;
    private float randomRotSpeed;
    public bool doRot = true;
    private void OnEnable()
    {
        randomRotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
        m_litmodel.transform.Rotate(Vector3.up * randomRotSpeed);
    }
    private void Update()
    {
        m_litmodel.transform.Rotate(Vector3.up * (doRot ? randomRotSpeed : 0) * Time.deltaTime);
    }
}
