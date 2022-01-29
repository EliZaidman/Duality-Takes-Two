using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fyiReader : MonoBehaviour
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
