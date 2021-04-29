using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificultad : MonoBehaviour
{
    public void ElegirDificultad(int dificultad)
    {
        PlayerPrefs.SetInt("Dificultad", dificultad);
    }
}
