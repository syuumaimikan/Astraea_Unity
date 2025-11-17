using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterItemUI : MonoBehaviour
{
    public Toggle toggle;                  // Toggle 本体
    public TextMeshProUGUI nameText;       // 名前表示
    public Image icon;                     // アイコン表示

    private string characterName;

    // Toggle変更時の通知用
    public Action<string, bool> onToggleChanged;

    public void Setup(string chName, Sprite chIcon)
    {
        characterName = chName;
        nameText.text = chName;
        icon.sprite = chIcon;

        // Toggleの値変更時にコールバック呼ぶ
        toggle.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(bool isOn)
    {
        onToggleChanged?.Invoke(characterName, isOn);
    }
}
