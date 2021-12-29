using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private int _poolSize = 10;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _poolNode;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _balanceStep = 1;
    [SerializeField] private int _balanceStartCount = 30;

    private ObjectsPool _pool;
    private Balance _balance;

    private void Start()
    {
        _balance = new Balance(_balanceStartCount);

        if(_uiController)
        {
            _uiController.UpdateBalanceText(_balance.Amount);
        }

        _pool = new ObjectsPool(_poolSize, _prefab, _poolNode);
    }

    public void SpawnCoin()
    {
        GameObject freeCoin = _pool.GetFreeItemOrCreate();
        freeCoin.GetComponent<Transform>().position = _spawnPoint.position;
        freeCoin.SetActive(true);

        _balance.Amount -= _balanceStep;
        UpdateBalanceText(_balance.Amount);
    }

    public void UpdateBalanceText(int coins)
    {
        _uiController.UpdateBalanceText(coins);
    }
}
