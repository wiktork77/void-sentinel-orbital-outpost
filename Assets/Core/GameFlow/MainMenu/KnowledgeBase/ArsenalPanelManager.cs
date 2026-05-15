using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArsenalPanelManager : GameEntitySlider<TowerType, TowerDataModel>
{
    public TMP_Text towerNameText;
    public Image towerImage;

    public TMP_Text towerDamageText;
    public TMP_Text towerCostText;
    public TMP_Text towerRangeText;
    public TMP_Text towerReloadTimeText;

    public TMP_Text towerDescriptionText;
    protected override TowerDataModel LoadEntityData()
    {
        return TowerDataModelResolver.getTowerDataModel(getCurrentEntity());
    }

    protected override List<TowerType> PopulateEntities()
    {
        return Enum.GetValues(typeof(TowerType)).Cast<TowerType>().ToList();
    }

    protected override void UpdateUI(TowerDataModel entityData)
    {
        towerNameText.SetText(entityData.Name);
        towerImage.sprite = TowerAvatarResolver.GetTowerSprite(getCurrentEntity());

        towerDamageText.SetText(entityData.Damage.ToString());
        towerCostText.SetText(entityData.Cost.ToString());
        towerRangeText.SetText(entityData.Range.ToString());
        towerReloadTimeText.SetText(entityData.ReloadTime.ToString());

        towerDescriptionText.SetText(entityData.Description.ToString());
    }
}
