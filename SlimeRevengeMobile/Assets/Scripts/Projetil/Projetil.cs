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

    private void Start() 
    {
        dano = projetilSO.dano;
        velocidade = projetilSO.velocidade;
        raioDeColisao = projetilSO.raioColisao;
        arteProjetil.sprite = projetilSO.arteProjetil;
        disparado = true;
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
        transform.Translate(Vector2.left * velocidade * Time.fixedDeltaTime);
    }
}
