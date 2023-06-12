using System.Collections.Generic;
using UnityEngine;

public class Way : ObjectPool
{
    [SerializeField] private GameObject[] _roadPrefabs;
    [SerializeField] private int _maxRoadPrefabsOnWay = 3;
    [SerializeField] private float _distanceBetweenRoad;
    [SerializeField] private float _speedWay;
    [SerializeField] private float _maxSpeedWay;
    [SerializeField] private bool _isAccelerationWay;

    private List<GameObject> _spawnedRoads = new List<GameObject>();
    private int _currentRoadsCount = 0;
    private float _offsetZ = -80f;
    private float _currentSpeedWay;

    private void Start()
    {
        foreach (var road in _roadPrefabs)
        {
            Initialize(road);
        }

        _currentSpeedWay = _speedWay;
    }

    private void Update()
    {
        MovingRoad();

        if (_currentRoadsCount != _maxRoadPrefabsOnWay)
        {
            ActivateRoad();        
        }
        
        DeactivateRoad();      
    }

    public void ChangedSpeed(bool isAcceleration)
    {
        _isAccelerationWay = isAcceleration;       
        _speedWay = _isAccelerationWay ? _maxSpeedWay : _currentSpeedWay;
    }

    private void MovingRoad()
    {
        foreach (GameObject road in _spawnedRoads)
        {
            road.transform.Translate(Vector3.back * _speedWay * Time.deltaTime);
        }
    }

    private void SetRoad(GameObject road, float spawnPointZ)
    {
        road.SetActive(true);
        road.transform.position = new Vector3(road.transform.position.x, road.transform.position.y, spawnPointZ);
        _spawnedRoads.Add(road);
        _currentRoadsCount++;
    }

    private void ActivateRoad()
    {
        if (_spawnedRoads.Count > 0)
        {
            if (TryGetRandomObject(out GameObject road))
            {
                SetRoad(road, _spawnedRoads[_spawnedRoads.Count - 1].transform.position.z + _distanceBetweenRoad);
            }
        }
        else if (_spawnedRoads.Count == 0)
        {
            if (TryGetFirstObject(out GameObject road))
            {
                SetRoad(road, road.transform.position.z);
            }
        }
    }

    private void DeactivateRoad()
    {
        if (_spawnedRoads[0].transform.localPosition.z < _offsetZ)
        {
            _spawnedRoads[0].SetActive(false);
            _spawnedRoads.RemoveAt(0);
            _currentRoadsCount--;
        }
    }
}