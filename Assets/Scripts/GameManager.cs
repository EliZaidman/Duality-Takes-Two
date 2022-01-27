using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    _instance = container.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }
    #endregion

    public bool hittingLight;

    public GameObject lightPlayer;
    public GameObject shadowPlayer;
    private void Update()
    {
        if (!hittingLight)
        {
        }
        //else
        //{
        //    lightPlayer.GetComponent<Light>().enabled = true;
        //}
    }
}
