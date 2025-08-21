using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpwner : MonoBehaviour
{
    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _moneyCount = 10;

    private List<Vector3> _spawnedPositions = new List<Vector3>();
    private float _minSqrDistance = 0.2f;

    private void Start()
    {
        SpawnMoney();
    }

    private void SpawnMoney()
    {
        for (int i = 0; i < _moneyCount; i++)
        {
            Vector3 spawnPoint = GetRandomPosition();
            Instantiate(_moneyPrefab, spawnPoint, Quaternion.identity);
            _spawnedPositions.Add(spawnPoint);
        }
    }

    private Vector3 GetRandomPosition()
    {
        bool isValidPosition = false;

        while (isValidPosition == false)
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            Vector3 randomPosition = _spawnPoints[randomIndex].position;

            if (IsPositionValid(randomPosition))
            {
                isValidPosition = true;
                return randomPosition;
            }
        }

        return Vector3.zero;
    }

    private bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 spawnedPos in _spawnedPositions)
        {
            if ((position - spawnedPos).sqrMagnitude < _minSqrDistance)
            {
                return false;
            }
        }

        return true;
    }
}
