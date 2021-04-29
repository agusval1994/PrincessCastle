using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    bool mover = true;
    public float speed = 2000;
    public Vector3 destination;
    public Rigidbody rb;
    public int tiempoDeVida;

    int vecesQuePuedeRebotar = 3;

    Monstruo monstruo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("DestruirBala", tiempoDeVida);
    }

    void Update()
    {
        if (mover)
        {
            rb.AddForce(transform.forward * speed);
            mover = false;
        }
    }

    public void DestruirBala()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "Monstruo" && vecesQuePuedeRebotar == 3)
        {
            monstruo = collision.gameObject.GetComponent<Monstruo>();
            monstruo.Morir();
        }

        RebotePelota();
    }

    public void RebotePelota()
    {
        vecesQuePuedeRebotar--;

        if (vecesQuePuedeRebotar > 0)
        {
            FindObjectOfType<AudioManager>().Play("RebotePelota");
        }
    }
}
