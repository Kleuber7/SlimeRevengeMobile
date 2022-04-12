using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torre : MonoBehaviour
{
    [Header ("Scriptable Object seta")]
    public float velocidadeDeAtaque;
    public float alcance;
    public Image arteTorre;
    public Projetil[] projeteis;
    public TorreSO torreSO;

    [Header ("Mecânicas usam (Precisam ser setados)")]
    public GameObject alvo;
    public Transform[] nextTarget;
    public float tempoRecargaInvocacao;
    public int waypointDestiny;

    void Start()
    {
        velocidadeDeAtaque = torreSO.velocidadeDeAtaque;
        alcance = torreSO.alcance;
        arteTorre.sprite = torreSO.arteTorre;
    }
}
