using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool jugar = false;

    [Header("OBJETOS")]
    public Camera camara;
    public GameObject mano;
    public GameObject princesa;
    public GameObject managerManoPrincesa;
    public GameObject particulasMuerteMano;
    public GameObject jefe;

    Animator animacionCamara;
    Animator animacionMano;
    Animator animacionPrincesa;
    Animator animacionManoPrincesa;
    Animator animacionJefe;


    [Header("UI")]
    public Image ganaste;
    public Image perdiste;
    public Text tiempo;
    public Text muertes;

    public int animMano = 0;

    public int puntos = 0;

    //Dificultad
    public static int speed = 5;
    int condicionDeGanar;
    int facil = 40;
    int medio = 45;
    int dificil = 50;
    float tiempoJuego = 60f;

    void Start()
    {
        animacionCamara = camara.GetComponent<Animator>();
        animacionMano = mano.GetComponent<Animator>();
        animacionPrincesa = princesa.GetComponent<Animator>();
        animacionManoPrincesa = managerManoPrincesa.GetComponent<Animator>();
        animacionJefe = jefe.GetComponent<Animator>();

        animacionPrincesa.SetInteger("Condicion", 1);

        Dificultad();

        Invoke("IniciarJuego", 0.5f);
    }

    private void Update()
    {
        if (jugar)
        {
            tiempoJuego -= Time.deltaTime;
            int aux = (int)tiempoJuego;
            tiempo.text = aux.ToString();
        }
    }

    public void IniciarJuego()
    {
        StartCoroutine("MovimientoMano");
        Invoke("AnimacionCamara", 1f);
    }

    public void AnimacionCamara()
    {
        animacionCamara.SetInteger("Condicion", 1);
        tiempo.gameObject.SetActive(true);
        muertes.gameObject.SetActive(true);
        jugar = true;
    }

    IEnumerator MovimientoMano()
    {
        animMano++;
        
        animacionMano.SetInteger("Condicion", animMano);

        if(animMano >= 6)
        {
            StartCoroutine("Perder");
            animacionJefe.SetInteger("Condicion", 1);
            StopCoroutine("MovimientoMano");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("RisaMonstruo");
            animacionJefe.SetInteger("Condicion", 1);
        }

        MonstruosSpeed();

        yield return new WaitForSeconds(2f);

        animacionJefe.SetInteger("Condicion", 0);

        yield return new WaitForSeconds(10f);

        StartCoroutine("MovimientoMano");
    }

    public void SumarPuntos()
    {
        puntos++;
        muertes.text = puntos.ToString();

        if(puntos >= condicionDeGanar)
        {
            StartCoroutine("Ganar");
            FindObjectOfType<AudioManager>().Play("Ganar");
        }
    }

    IEnumerator Ganar()
    {
        jugar = false;
        animacionCamara.SetInteger("Condicion", 2);
        StopCoroutine("MovimientoMano");
        animacionPrincesa.SetInteger("Condicion", 2);

        yield return new WaitForSeconds(1f);

        ganaste.gameObject.SetActive(true);
        Instantiate(particulasMuerteMano, mano.transform.position, mano.transform.rotation);
        Destroy(mano);
    }

    IEnumerator Perder()
    {
        jugar = false;
        perdiste.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Perder");

        yield return new WaitForSeconds(1f);

        FindObjectOfType<AudioManager>().Play("RisaFinal");
        animacionManoPrincesa.SetInteger("Condicion", 1);
    }

    public void Dificultad()
    {
        int dificultad = PlayerPrefs.GetInt("Dificultad");

        if(dificultad == 1)
        {
            condicionDeGanar = facil;
        }

        if(dificultad == 2)
        {
            condicionDeGanar = medio;
        }

        if(dificultad == 3)
        {
            condicionDeGanar = dificil;
        }
    }

    public void MonstruosSpeed()
    {
        if(animMano == 4)
        {
            speed = 4;
        }

        if(animMano == 5)
        {
            speed = 3;
        }
    }
}
