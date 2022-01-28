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

    public Canvas mainMenu;
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

        if (!IsWaveOngoing)
        {
            Timer -= Time.deltaTime;
            //_countDown.text = Timer.ToString("0");

            if (Timer <= 0)
                IsWaveOngoing = true;
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
        mainMenu.enabled = false;
    }

    public void LostGame()
    {
        Debug.Log("HIT PLAYER");
    }

    #endregion
}
