using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstruo : MonoBehaviour
{
    Animator animacion;

    bool primeraVez = true;

    bool unaVez = true;

    bool puedeMorir = true;

    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.jugar)
        {
            if (unaVez)
            {
                StartCoroutine("MovimientoMonstruo");
                unaVez = false;
            }
        }
    }

    public void Morir()
    {
        if (puedeMorir)
        {
            animacion.SetInteger("Condicion", 3);
            FindObjectOfType<AudioManager>().Play("MorirMonstruo");
            StopCoroutine("MovimientoMonstruo");
            StartCoroutine("MovimientoMonstruo");
            FindObjectOfType<GameManager>().SumarPuntos();
        }
    }

    public void Subir()
    {
        animacion.SetInteger("Condicion", 2);
    }

    public void Bajar()
    {
        animacion.SetInteger("Condicion", 1);
    }

    IEnumerator MovimientoMonstruo()
    {
        //Empieza el juego
        if (primeraVez)
        {
            int rand = Random.Range(0, 5);

            yield return new WaitForSeconds(rand);

            primeraVez = false;
        }
        else
        {
            yield return new WaitForSeconds(GameManager.speed);
        }

        Subir();
        puedeMorir = true;

        yield return new WaitForSeconds(GameManager.speed);

        Bajar();
        puedeMorir = false;
        StartCoroutine("MovimientoMonstruo");
    }
}
