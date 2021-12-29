using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Balance
{
    private int _startAmount;
    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value <= 0 ? _startAmount : value;
        }
    }

    public Balance()
    {
        Amount = 1;
        _startAmount = 1;
    }

    public Balance(int value)
    {
        Amount = value;
        _startAmount = value;
    }
}
