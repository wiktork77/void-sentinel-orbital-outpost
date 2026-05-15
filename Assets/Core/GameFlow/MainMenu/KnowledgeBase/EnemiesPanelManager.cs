using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesPanelManager : GameEntitySlider<EnemyType, EnemyDataModel>
{
    public TMP_Text enemyNameText;
    public Image enemyImage;

    public TMP_Text enemyHealthText;
    public TMP_Text enemyLootText;
    public TMP_Text enemyDamageText;
    public TMP_Text enemySpeedText;

    public TMP_Text enemyDescriptionText;


    protected override EnemyDataModel LoadEntityData()
    {
        return EnemyDataModelResolver.getEnemyDataModel(getCurrentEntity());
    }

    protected override void UpdateUI(EnemyDataModel entityData)
    {
        enemyNameText.SetText(entityData.Name);
        enemyImage.sprite = EnemyAvatarResolver.GetEnemySprite(getCurrentEntity());

        enemyHealthText.SetText(entityData.MaxHealth.ToString());
        enemyLootText.SetText(entityData.Loot.ToString());
        enemyDamageText.SetText(ClearDamageToBaseText(entityData.DamageToBase));
        enemySpeedText.SetText(entityData.Speed.ToString());

        enemyDescriptionText.SetText(entityData.Description);

    }

    protected override List<EnemyType> PopulateEntities()
    {
        return Enum.GetValues(typeof(EnemyType)).Cast<EnemyType>().ToList();
    }

    private string ClearDamageToBaseText(int damageToBaseText)
    {
        if (damageToBaseText == int.MaxValue)
        {
            return "\u221E"; // nieskonczonosc
        }
        return damageToBaseText.ToString();
    }

}
