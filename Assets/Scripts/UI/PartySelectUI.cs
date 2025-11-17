using UnityEngine;
using System.Collections.Generic;

public class PartySelectUI : MonoBehaviour
{
    public Transform characterListParent;  // Content の Transform
    public GameObject characterItemPrefab; // CharacterItem Prefab
    public ChStatus[] chDatabase;          // マスターデータ

    private List<string> selectedCharacters = new List<string>();

    void Start()
    {
        GenerateCharacterList();
    }

    void GenerateCharacterList()
    {
        foreach (var ch in chDatabase)
        {
            GameObject obj = Instantiate(characterItemPrefab, characterListParent);
            CharacterItemUI ui = obj.GetComponent<CharacterItemUI>();

            ui.Setup(ch.chName, ch.icon);
            ui.onToggleChanged = OnSelectCharacter;
        }
    }

    private void OnSelectCharacter(string name, bool isOn)
    {
        if (isOn)
        {
            if (selectedCharacters.Count >= 4)
            {
                // 選択上限を超える場合は Toggle を OFF に戻す
                foreach (Transform child in characterListParent)
                {
                    CharacterItemUI ui = child.GetComponent<CharacterItemUI>();
                    if (ui != null && ui.characterName == name)
                    {
                        ui.toggle.isOn = false;
                        break;
                    }
                }
                return;
            }

            selectedCharacters.Add(name);
        }
        else
        {
            selectedCharacters.Remove(name);
        }

        Debug.Log("現在の編成: " + string.Join(",", selectedCharacters));
    }


    public void OnClick_Save()
    {
        PartySaveSystem.SaveParty(selectedCharacters);
        Debug.Log("編成を保存しました！");
    }
}
