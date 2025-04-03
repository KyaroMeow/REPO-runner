using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;

    private void Awake()
    {
        MoneyController.MoneyChanged += MoneyController_MoneyChanged;
    }

    private void Start()
    {
        _money.text = MoneyController.Money.ToString();
    }

    private void MoneyController_MoneyChanged(int arg0)
    {
        _money.text = arg0.ToString();
    }
}
