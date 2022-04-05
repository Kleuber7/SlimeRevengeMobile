using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreCombate : MonoBehaviour
{
    public Torre torre;
    public LayerMask layer;
    public bool invasaoDePerimetro;
    public int municao;
    public float tempoRecargaMunicao;
    public bool recarregando;
    public bool podeAtirar;

    private void Start() 
    {
        municao = torre.projeteis.Length - 1;
        recarregando = false;
        podeAtirar = true;
    }

    private void FixedUpdate() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, torre.alcance);
        if(hit)
        {
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                invasaoDePerimetro = true;
                torre.alvo = hit.collider.gameObject;
            }
            else
            {
                invasaoDePerimetro = false;
                torre.alvo = null;
            }
        }

        if(invasaoDePerimetro)
        {
            if(podeAtirar)
            {
                StartCoroutine(Fogo());
            }
        }
    }

    IEnumerator Fogo()
    {
        podeAtirar = false;
        yield return new WaitForSeconds(1/torre.velocidadeDeAtaque);
        torre.projeteis[municao].gameObject.SetActive(true);
        municao--;
        if(municao < 0)
        {
            if(!recarregando)
            {
                StartCoroutine(Recarga());
            }
        }
        else
        {
            podeAtirar = true;
        }
    }

    IEnumerator Recarga()
    {
        recarregando = true;
        yield return new WaitForSeconds(tempoRecargaMunicao);
        municao = torre.projeteis.Length - 1;
        recarregando = false;
        podeAtirar = true;
    }
}
