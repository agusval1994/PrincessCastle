using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject go;
    bool visible = false;

    public void Sig()
    {
        visible = !visible;

        go.gameObject.SetActive(visible);
    }
}
