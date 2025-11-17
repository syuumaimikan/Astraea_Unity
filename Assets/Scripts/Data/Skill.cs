using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "ScriptableObjects/Skill", order = 2)]
public class Skill : ScriptableObject
{
    public string skillName;  // スキル名
    public string description; // スキルの説明
    public int damage;         // スキルのダメージ
    public float cooldown;     // スキルのクールダウン時間
}