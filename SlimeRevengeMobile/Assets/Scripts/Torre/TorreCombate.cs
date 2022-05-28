using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreCombate : MonoBehaviour
{
    public Torre torre;
    public bool invasaoDePerimetro;
    public int municao;
    public float tempoRecargaMunicao;
    public bool recarregando;
    public bool podeAtirar;
    public AnimacaoTorres animacao;

    private void Start() 
    {
        municao = torre.projeteis.Length - 1;
        recarregando = false;
        podeAtirar = true;
    }

    private void FixedUpdate() 
    {
        if(invasaoDePerimetro)
        {
            if(podeAtirar)
            {
                StartCoroutine(Fogo());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Inimigo")
        {
            invasaoDePerimetro = true;
            torre.alvo = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Inimigo")
        {
            invasaoDePerimetro = false;
            torre.alvo = null;
            animacao.atacar = false;
            animacao.iddle = true;
        }
    }

    IEnumerator Fogo()
    {
        podeAtirar = false;
        animacao.atacar = false;
        yield return new WaitForSeconds(1/torre.velocidadeDeAtaque);
        if(!invasaoDePerimetro)
            yield return null;
        
        torre.projeteis[municao].gameObject.SetActive(true);
        municao--;
        animacao.atacar = true;
        if(municao < 0)
        {
            if(!recarregando)
            {
                StartCoroutine(Recarga());
            }
            animacao.atacar = false;
            animacao.iddle = true;
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
