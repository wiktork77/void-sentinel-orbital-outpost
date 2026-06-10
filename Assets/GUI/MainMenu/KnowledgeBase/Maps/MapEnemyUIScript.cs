using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapEnemyUIScript : MonoBehaviour
{
    public Image enemyIcon;
    public TMP_Text enemyNameText;

    public void Setup(string name, Sprite icon)
    {
        if (enemyNameText != null) enemyNameText.SetText(name);
        if (enemyIcon != null) enemyIcon.sprite = icon;
    }
}
