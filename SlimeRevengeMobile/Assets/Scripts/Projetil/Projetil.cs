using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projetil : MonoBehaviour
{
    public float dano;
    public float velocidade;
    public float raioDeColisao;
    public Image arteProjetil;
    public ProjetilSO projetilSO;
    public Torre torre;
    public bool disparado;
    public Vector3 posicaoInicial;

    private void Start()
    {
        posicaoInicial = transform.position;
        dano = projetilSO.dano;
        velocidade = projetilSO.velocidade;
        raioDeColisao = projetilSO.raioColisao;
        arteProjetil.sprite = projetilSO.arteProjetil;
        disparado = true;
    }

    private void OnEnable()
    {
        StartCoroutine(TempoExpira());
    }

    private void FixedUpdate()
    {
        if(disparado)
        {
            Disparo();
        }
    }

    public void Disparo()
    {
        transform.Translate(Vector2.right * velocidade * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Inimigo")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(dano);
            this.gameObject.SetActive(false);
            transform.position = posicaoInicial;
        }
    }

    IEnumerator TempoExpira()
    {
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
        transform.position = posicaoInicial;
    }
}
