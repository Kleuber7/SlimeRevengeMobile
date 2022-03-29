using UnityEngine;

[CreateAssetMenu(fileName = "Torre", menuName = "Torre")]
public class TorreSO : ScriptableObject
{
    public int id;
    public float velocidadeDeAtaque;
    public float alcance;
    public Sprite arteTorre;
    public ProjetilSO projetil;
}
