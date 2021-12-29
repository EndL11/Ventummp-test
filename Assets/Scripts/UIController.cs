using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _balanceAmountText;

    public void UpdateBalanceText(int coins)
    {
        if(_balanceAmountText)
        {
            _balanceAmountText.text = coins.ToString();
        }
    }

}
