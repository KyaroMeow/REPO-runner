using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MoneyController : MonoBehaviour
{
    public static int Money { get; private set; }
    public static event UnityAction<int> MoneyChanged;

    public static void MoneyOperation(int value)
    {
        Money += value;
        MoneyChanged?.Invoke(Money);
    }
}
