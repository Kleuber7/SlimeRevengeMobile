using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoDeTorre : MonoBehaviour
{
    public RectTransform torres;
    public GameObject UISelecaoDeTorres;
    public bool ocupada;
    public float tempoRecargaInvocacao;
    static bool podeInvocar;

    private void Start() 
    {
        podeInvocar = true;
        ocupada = false;
    }

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
            if(podeInvocar)
            {
                torres.GetChild(torreIndex).gameObject.SetActive(true);
                AtivaUISelecaoDeTorre();
                ocupada = true;
                tempoRecargaInvocacao = torres.GetChild(torreIndex).gameObject.GetComponent<Torre>().tempoRecargaInvocacao;
                StartCoroutine(RecargaInvocacao());
                this.gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }

    public IEnumerator RecargaInvocacao()
    {
        podeInvocar = false;
        yield return new WaitForSeconds(tempoRecargaInvocacao);
        podeInvocar = true;
    }
}
