using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StringCaller : MonoBehaviour
{

    public List<string> fyiFacts = new List<string>();

    public TextMeshProUGUI factsUI;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            readFact();
        }
    }

    private void readFact()
    {
        factsUI.text = fyiFacts[Random.Range(0, fyiFacts.Count)];
    }
}
