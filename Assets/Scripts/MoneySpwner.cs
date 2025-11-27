using System.Collections.Generic;
using UnityEngine;


public class MoneySpwner : MonoBehaviour
{
    [SerializeField] private Money _moneyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _moneyCount = 10;

    private List<Vector3> _spawnedPositions = new List<Vector3>();
    private List<Transform> _freeSpawnPoints = new List<Transform>();
    private List<Transform> _takenSpawnPoints = new List<Transform>();
    private List<Money> _spawnedMoney = new List<Money>();

    private void Awake()
    {
        _freeSpawnPoints.AddRange(_spawnPoints);
    }
    private void Start()
    {
        SpawnMoney();
    }

    private void SpawnMoney()
    {
        if(_freeSpawnPoints.Count < _moneyCount)
        {
            Debug.LogWarning("Not enough spawn points for the requested money count.");
            _moneyCount = _freeSpawnPoints.Count;
        }

        for (int i = 0; i < _moneyCount; i++)
        {
            Transform spawnPoint = _freeSpawnPoints[0];
            _takenSpawnPoints.Add(spawnPoint);
            _freeSpawnPoints.Remove(spawnPoint);

            var money = Instantiate(_moneyPrefab, spawnPoint.position, Quaternion.identity);
            _spawnedPositions.Add(spawnPoint.position);
            _spawnedMoney.Add(money);
            money.OnDie += () => OnMoneyCollected(money, spawnPoint);
        }
    }

    private void OnMoneyCollected(Money money, Transform spawnPoint)
    {
        _spawnedMoney.Remove(money);
        _takenSpawnPoints.Remove(spawnPoint);
        _freeSpawnPoints.Add(spawnPoint);

        money.OnDie -= () => OnMoneyCollected(money, spawnPoint);
        Destroy(money.gameObject);
    }
}
