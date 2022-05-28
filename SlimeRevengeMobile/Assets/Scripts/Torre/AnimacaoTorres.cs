using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacaoTorres : MonoBehaviour
{
    public bool atacar;
    public bool iddle;
    public Image arteAtacar;
    public Image arteIddle;
    public SpriteRenderer spriteAnimator;
    public Animator animator;

    private void Start() 
    {
        iddle = true;
        animator.SetBool("Iddle", true);
        atacar = false;
        animator.SetBool("Atacar", false);
    }

    private void Update() 
    {
        if(iddle)
        {
            Iddle();
        }
        if(atacar)
        {
            Atacar();
        }
    }

    public void Atacar()
    {
        animator.SetBool("Iddle", false);
        animator.SetBool("Atacar", true);
        arteIddle.gameObject.SetActive(false);
        arteAtacar.gameObject.SetActive(true);
        arteAtacar.sprite = spriteAnimator.sprite;
    }

    public void Iddle()
    {
        animator.SetBool("Atacar", false);
        animator.SetBool("Iddle", true);
        arteAtacar.gameObject.SetActive(false);
        arteIddle.gameObject.SetActive(true);
        arteIddle.sprite = spriteAnimator.sprite;
    }
}
