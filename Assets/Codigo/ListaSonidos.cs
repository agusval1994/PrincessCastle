using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaSonidos : MonoBehaviour
{
    public void ActivarDesactivar()
    {
        FindObjectOfType<AudioManager>().Play("ActivarDesactivar");
    }

    public void VolverInicio()
    {
        FindObjectOfType<AudioManager>().Play("VolverInicio");
    }

    public void Cancelar()
    {
        FindObjectOfType<AudioManager>().Play("Cancelar");
    }

    public void Continuar()
    {
        FindObjectOfType<AudioManager>().Play("BotonContinuar");
    }

    public void Eleccion()
    {
        FindObjectOfType<AudioManager>().Play("Eleccion");
    }

    public void Perder()
    {
        FindObjectOfType<AudioManager>().Play("Perder");
    }

    public void Ganar()
    {
        FindObjectOfType<AudioManager>().Play("Ganar");
    }

    public void SubirMonstruo()
    {
        FindObjectOfType<AudioManager>().Play("SubirMonstruo");
    }

    public void MorirMonstruo()
    {
        FindObjectOfType<AudioManager>().Play("MorirMonstruo");
    }

    public void RisaMonstruo()
    {
        FindObjectOfType<AudioManager>().Play("RisaMonstruo");
    }

    public void RisaFinal()
    {
        FindObjectOfType<AudioManager>().Play("RisaFinal");
    }
}
