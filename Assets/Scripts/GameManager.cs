using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Game Manager not loaded properly");

            return _instance;
        }
    }
    #endregion

    #region Serialized Fields
    [SerializeField]
    private SpawnerManager _spawnerManager;

    //[SerializeField]
    //private TextMeshProUGUI _countDown, _levelText, _nextLevelTxt;

    [SerializeField]
    private bool _isWaveOngoing = false;
    #endregion

    #region Properties
    public bool IsWaveOngoing { get => _isWaveOngoing; set => _isWaveOngoing = value; }
    #endregion

    #region Public Fields
    public int TargetsRemaining;
    public float Timer, TimeSinceLevelStart;

    public List<GameObject> targetPosition;

    public GameObject WinWindow;
    public GameObject LoseWindow;
    private bool _hasWon = false;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        if (_instance == null)
            _instance = this;

        else
            Destroy(this);
    }

    void Update()
    {
        //_levelText.text = Level.ToString("0");

        if (IsWaveOngoing)
        {
            Timer += Time.deltaTime;
            //_countDown.text = Timer.ToString("0");

            if (Timer >= 180 && !_hasWon)
            {
                _hasWon = true;
                Win();

            }
        }


        TimeSinceLevelStart += Time.deltaTime;
        //if (IsWaveOngoing == false)
        //    TimeSinceLevelStart = 0;
    }
    #endregion

    #region Methods

    public void StartGame()
    {
        IsWaveOngoing = true;
    }

    public void LostGame()
    {
        LoseWindow.SetActive(true);
    }

    public void StartSpawning()
    {
        _isWaveOngoing = true;
    }
    private void Win()
    {
        WinWindow.SetActive(true);
    }

    #endregion
}
