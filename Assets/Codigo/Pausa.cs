using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public void Continuar()
    {
        Time.timeScale = 1f;
    }

    public void Pausar()
    {
        Time.timeScale = 0f;
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Inicio");
    }
}
