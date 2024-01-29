using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    float x, y, result;
    float operacion;
    float aleatorio;
    public float propio;
    private void Start()
    {
        aleatorio = UnityEngine.Random.Range(1, 4);
        Generador();
    }
    private void Update()
    {
        if (aleatorio == 1)
        {
            operacion = x * y;      
        }
        else if (aleatorio == 2)
        {
            operacion = x + y;
        }
        else if (aleatorio == 3)
        {
            operacion = x - y;
        }
        else if (aleatorio == 4)
        {
            operacion = x % y;
        }
    }
    void Generador()
    {
        x = UnityEngine.Random.Range(0, 100);
        y = UnityEngine.Random.Range(0, 100);
        aleatorio = UnityEngine.Random.Range(1, 4);
    }
}
