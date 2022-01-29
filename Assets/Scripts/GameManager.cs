using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public float timeRemaining = 180;
    public bool timerIsRunning = false;
    [SerializeField] private TextMeshProUGUI timeText;
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

    public SpawnerManager _spawnerManager;

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
        if (IsWaveOngoing)
        {
            Timer += Time.deltaTime;

            //_countDown.text = Timer.ToString("0");
            timerIsRunning = true;
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
            }

            if (Timer >= 180 && !_hasWon)
            {
                _hasWon = true;
                Win();

            }
        }
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
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //[System.Obsolete]
    public void ResetGame()
    {
        foreach (GameObject enemy in FindObjectOfType<SpawnerManager>().EnemiesInScene)
            Destroy(enemy);
        FindObjectOfType<SpawnerManager>().EnemiesInScene.Clear();
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
