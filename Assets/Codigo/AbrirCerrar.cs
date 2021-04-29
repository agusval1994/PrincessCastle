using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrar : MonoBehaviour
{
    public GameObject cosaAbrir;
    public GameObject cosaCerrar;

    public void Abrir()
    {
        cosaAbrir.gameObject.SetActive(true);
    }

    public void Cerrar()
    {
        cosaCerrar.gameObject.SetActive(false);
    }
}
