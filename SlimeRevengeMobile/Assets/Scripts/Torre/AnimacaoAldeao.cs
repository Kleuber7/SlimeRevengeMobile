using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacaoAldeao : MonoBehaviour
{
    public Image arteAnimacao;
    public SpriteRenderer spriteAnimacao;

    private void Update() 
    {
        Atacar();
    }

    public void Atacar()
    {
        arteAnimacao.gameObject.SetActive(true);
        arteAnimacao.sprite = spriteAnimacao.sprite;
    }
}
