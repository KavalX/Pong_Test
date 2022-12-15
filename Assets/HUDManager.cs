using System;
using TMPro;
using UnityEngine;

public class HUDManager :MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI textP1;
    [SerializeField] private TextMeshProUGUI textP2;

    private void Awake()
    {
        GameManager.Instance.HUDManager = this;
    }

    public void setPoint(int playerNumb, int Points)
    {
        if (playerNumb == 1)
        {
            textP1.text = Points.ToString();
        }
        if (playerNumb == 2)
        {
            textP2.text = Points.ToString();
        }
    }
}