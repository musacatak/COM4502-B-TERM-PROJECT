using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gemText;

    public void UpdateGemText(Inventory inventory)
    {
        gemText.text = inventory.NumberOfGems.ToString();
    }
}
