using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public float damage;
    public float speed;
    public Sprite art;
    public float health;
    public float maxHealth;
}
