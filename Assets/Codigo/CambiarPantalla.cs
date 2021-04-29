using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarPantalla : MonoBehaviour
{
    public string pantalla;

    public void CambioDePantalla()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(pantalla);
    }
}
