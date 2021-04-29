using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBala : MonoBehaviour
{
    public GameObject bullet;

    public float speed = 10;
    private Vector3 destination;
    private Vector3 posInicial;
    private float distance;
    private Bala bala;

    void Update()
    {
        if (GameManager.jugar)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 clickPoint = Input.mousePosition;
                var createPos = Camera.main.ScreenToWorldPoint(clickPoint);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    destination = hit.point;
                    transform.position = createPos;
                    this.transform.LookAt(destination);

                    Instantiate(bullet, createPos, transform.rotation);

                    FindObjectOfType<AudioManager>().Play("TirarPelota");
                }
            }
        }
    }
}
