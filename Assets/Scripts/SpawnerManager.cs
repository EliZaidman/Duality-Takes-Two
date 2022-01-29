using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour
{
    #region Singleton
    private static SpawnerManager _instance;
    public static SpawnerManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Spawn Manager not loaded properly");

            return _instance;
        }
    }

    private SpawnerManager()
    {

    }
    #endregion

    #region Serialized Fields
    [SerializeField]
    public List<GameObject> _spawners = new List<GameObject>(4);

    [SerializeField]
    private List<GameObject> _allEnemies;

    public int _Level;

    [SerializeField]
    public GameObject _enemy;

    private RectTransform _rTr;

    [SerializeField]
    public List<GameObject> EnemiesInScene = new List<GameObject>();

    [SerializeField]
    public Vector2 _timeBetweenSpawnsRange;

  

    //public AudioClip[] randomSpawnSounds;

    #endregion

    #region Public Fields
    private float _currentTimeBetweenSpawns;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _currentTimeBetweenSpawns = GetRandomSpawnRange();
        Invoke("changeRate",90);
    }
    private float GetRandomSpawnRange()
    {
        return Random.Range(_timeBetweenSpawnsRange.x, _timeBetweenSpawnsRange.y);
    }
    private void Update()
    {
        GameObject selectedSpawner = _spawners[Random.Range(0, 6)];

        if (_rTr == null)
            _rTr = selectedSpawner.GetComponent<RectTransform>();
        //else
        //    Debug.Log("Between Levels");

        float rectX = Random.Range(_rTr.rect.xMin, _rTr.rect.xMax);
        float rectY = Random.Range(_rTr.rect.yMin, _rTr.rect.yMax);

        Vector2 randomPosInsideSpawner = new Vector2(rectX, rectY);

        if (GameManager.Instance.IsWaveOngoing)
        {

            if (_currentTimeBetweenSpawns <= 0)
            {
                GameObject newEnemy = Instantiate(_allEnemies[Random.Range(0,_allEnemies.Count)], (Vector2)_spawners[Random.Range(0, 6)].transform.position /*+ randomPosInsideSpawner*/, Quaternion.identity);

                EnemiesInScene.Add(newEnemy);
                _currentTimeBetweenSpawns = GetRandomSpawnRange();
            }

            else
            {
                _currentTimeBetweenSpawns -= Time.deltaTime;
                _rTr = null;
            }
        }
        
    }

    public void changeRate()
    {
        _timeBetweenSpawnsRange.x = 1;
    }
    #endregion
}
