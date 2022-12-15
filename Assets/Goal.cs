using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.name.Equals("Goal1"))
        {
            print("Marca el jugador 2");

            GameManager.Instance.AddPoint(1);
        }
        if (this.name.Equals("Goal2"))
        {
            print("Marca el jugador 1");

            GameManager.Instance.AddPoint(2);
        }
    }
}
