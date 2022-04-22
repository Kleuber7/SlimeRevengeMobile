using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public Transform[] waves;
    public Transform waveAtual;
    public int waveIndex;
    public int inimigosIndex;
    public int tempoEsperaWave;
    public float contadorWave;
    public float tempoEntreInvocacoes;
    public bool restaInimigos;
    public bool waveIniciada;
    public bool podeInvocar;
    public bool vitoria;
    public bool startGame;
    public Transform posicaoInicial;

    private void Start()
    {
        waveIndex = 0;
        inimigosIndex = 0;
        waveAtual = waves[waveIndex];
        contadorWave = tempoEsperaWave;
        waveIniciada = false;
        podeInvocar = true;
        vitoria = false;
        if (waveAtual.childCount > 0)
        {
            restaInimigos = true;
        }
    }

    private void FixedUpdate()
    {
        if (!vitoria)
        {
            if (startGame)
            {
                if (waveIndex >= waves.Length)
                {
                    waveIndex = waves.Length - 1;
                }

                if (contadorWave > 0)
                {
                    contadorWave -= 1 * Time.fixedDeltaTime;
                }
                else
                {
                    contadorWave = 0;
                    if (!waveIniciada)
                    {
                        waveIniciada = true;
                    }
                    else
                    {
                        if (waveAtual.childCount <= inimigosIndex)
                        {
                            foreach (Transform inimigo in waveAtual)
                            {
                                if (inimigo.gameObject.activeSelf)
                                {
                                    restaInimigos = true;
                                    break;
                                }
                                else
                                {
                                    restaInimigos = false;
                                }
                            }

                            if (!restaInimigos)
                            {
                                waveIniciada = false;
                                contadorWave = tempoEsperaWave;
                                inimigosIndex = 0;
                                waveIndex++;
                                if (waveIndex < waves.Length)
                                {
                                    waveAtual = waves[waveIndex];
                                }
                                else
                                {
                                    startGame = false;
                                    vitoria = true;
                                }
                            }
                        }
                        else
                        {
                            Invocar();
                        }
                    }
                }
            }
        }
    }

    public void Invocar()
    {
        if (podeInvocar)
        {
            if (waveAtual.childCount > inimigosIndex)
            {
                waveAtual.GetChild(inimigosIndex).gameObject.transform.position = posicaoInicial.position;
                waveAtual.GetChild(inimigosIndex).gameObject.SetActive(true);
                inimigosIndex++;
            }
            StartCoroutine(TempoInvocacaoWave());
        }
    }

    public void IniciarWave()
    {
        startGame = true;
    }

    IEnumerator TempoInvocacaoWave()
    {
        podeInvocar = false;
        yield return new WaitForSeconds(tempoEntreInvocacoes);
        podeInvocar = true;
    }
}
