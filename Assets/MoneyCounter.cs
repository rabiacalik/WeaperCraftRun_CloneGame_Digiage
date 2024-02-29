using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyCounter : MonoBehaviour
{
    public Text moneyText;
    public int moneyCounter = 0;

    private void Update()
    {
        moneyText.text = moneyCounter.ToString() + "$";
    }


}
