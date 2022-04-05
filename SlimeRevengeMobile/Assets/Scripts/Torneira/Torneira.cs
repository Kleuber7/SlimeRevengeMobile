using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torneira : MonoBehaviour
{
    public Image arteTorneira;
    public TorneiraSO torneiraSO;

    private void Start() 
    {
        arteTorneira.sprite = torneiraSO.arteTorneira;
    }
}
