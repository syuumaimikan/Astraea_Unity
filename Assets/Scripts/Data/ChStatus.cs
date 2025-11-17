using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "ScriptableObjects/ChStats", order = 1)]
public class ChStatus : ScriptableObject
{
    public string enemyName;  // 敵の名前
    public int health;        // 体力
    public int attackPower;   // 攻撃力
    public float speed;       // 移動速度
    public Sprite enemySprite; // 敵の見た目
    public Skill[] skills;    // 敵が持つスキルの配列
}