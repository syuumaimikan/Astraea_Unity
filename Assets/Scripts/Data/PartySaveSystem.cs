using UnityEngine;
using System.IO;

public static class PartySaveSystem
{
    private static string SavePath => Application.persistentDataPath + "/party.json";

    public static void SaveParty(List<string> party)
    {
        PartySaveData data = new PartySaveData();
        data.party = party;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("編成保存: " + SavePath);
    }

    public static PartySaveData LoadParty()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("編成データなし。");
            return null;
        }

        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<PartySaveData>(json);
    }
}
