using UnityEngine;

[CreateAssetMenu(fileName = "NewParty", menuName = "ScriptableObjects/PartyData", order = 3)]
public class PartyData : ScriptableObject
{
    public ChStatus[] partyMembers; // 編成されたキャラの配列
}
