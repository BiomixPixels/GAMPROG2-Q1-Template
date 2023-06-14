using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DisplayManaBar : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image fill;

    private void UpdateBar()
    {
        Player player = InventoryManager.Instance.player;
        float currentMana = player.GetAttributeValue(AttributeType.MANA);
        fill.fillAmount = currentMana / player.maxMana;
        text.text = ($"MANA {currentMana} / {player.maxMana}");
    }

    private void Update()
    {
        UpdateBar();
    }
}
