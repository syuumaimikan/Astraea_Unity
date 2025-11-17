using UnityEngine;
using System.Collections.Generic;

public class ChManager : MonoBehaviour
{
    public ChStatus[] chDatabase;   // マスターデータ
    public Transform parent;
    public List<GameObject> chPosition;

    void Start()
    {
        // JSON から編成をロード
        var saveData = PartySaveSystem.LoadParty();
        if (saveData == null) return;

        int count = Mathf.Min(saveData.party.Count, chPosition.Count);

        for (int i = 0; i < count; i++)
        {
            // 名前から ChStatus を探す
            ChStatus ch = FindStatus(saveData.party[i]);
            if (ch == null) continue;

            // ログ
            Debug.Log($"{ch.chName} を生成");

            // 生成
            Instantiate(
                ch.chObject,
                chPosition[i].transform.position,
                Quaternion.identity,
                parent
            );
        }
    }

    ChStatus FindStatus(string name)
    {
        foreach (var ch in chDatabase)
        {
            if (ch.chName == name)
                return ch;
        }
        Debug.LogWarning("見つからないキャラ: " + name);
        return null;
    }
}
