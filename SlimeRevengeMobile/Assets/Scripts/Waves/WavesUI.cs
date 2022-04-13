using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavesUI : MonoBehaviour
{
    public Waves wavesScript;
    public TextMeshProUGUI textoWave1;
    public TextMeshProUGUI textoWave2;
    public TextMeshProUGUI textoWave3;
    public TextMeshProUGUI textoVitoria;

    private void Update() 
    {
        if(!wavesScript.vitoria)
        {
            if(!wavesScript.waveIniciada)
            {
                if(wavesScript.contadorWave > 0)
                {
                    if(wavesScript.waveIndex == 0)
                    {
                        textoWave1.gameObject.SetActive(true);
                    }

                    if(wavesScript.waveIndex == 1)
                    {
                        textoWave2.gameObject.SetActive(true);
                    }

                    if(wavesScript.waveIndex == 2)
                    {
                        textoWave3.gameObject.SetActive(true);
                    }
                }
                else
                {
                    textoWave1.gameObject.SetActive(false);
                    textoWave2.gameObject.SetActive(false);
                    textoWave3.gameObject.SetActive(false);
                }
            }
            textoVitoria.gameObject.SetActive(false);
        }
        else
        {
            textoVitoria.gameObject.SetActive(true);
        }
    }
}
