using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecaoDeTorre : MonoBehaviour
{
    public RectTransform torres;
    public GameObject UISelecaoDeTorres;
    public bool ocupada;

    public void AtivaUISelecaoDeTorre()
    {
        if(!ocupada)
        {
            if(!UISelecaoDeTorres.activeSelf)
            {
                UISelecaoDeTorres.SetActive(true);
            }
            else
            {
                UISelecaoDeTorres.SetActive(false);
            }
        }
    }

    public void AtivaTorre(int torreIndex)
    {
        if(!ocupada)
        {
            torres.GetChild(torreIndex).gameObject.SetActive(true);
            Debug.Log(torres.GetChild(torreIndex).name);
            AtivaUISelecaoDeTorre();
            ocupada = true;
        }
    }
}
