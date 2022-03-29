using UnityEngine;

[CreateAssetMenu(fileName = "Projetil", menuName = "Projetil")]
public class ProjetilSO : ScriptableObject
{
    public float dano;
    public float velocidade;
    public float raioColisao;
    public Sprite arteProjetil;
}
