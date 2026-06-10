using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapsPanelManager : GameEntitySlider<MapType, MapDataModel>
{
    public TMP_Text mapNameText;
    public Image mapImage;

    public TMP_Text mapInitialCurrencyText;
    public TMP_Text mapInitialHealthText;

    public TMP_Text mapDescriptionText;


    public GameObject lockedMapGO;

    public GameObject enemiesBar;
    public GameObject enemyUIPrefab;

    protected override MapDataModel LoadEntityData()
    {
        return MapDataModelResolver.getMapDataModel(getCurrentEntity());
    }

    protected override List<MapType> PopulateEntities()
    {
        List<MapType> ignored = new List<MapType>() { MapType.GODMODE };

        var list = Enum.GetValues(typeof(MapType)).Cast<MapType>().ToList();
        list.RemoveAll(item => ignored.Contains(item));

        return list;
    }

    protected override void UpdateUI(MapDataModel entityData)
    {
        lockedMapGO.SetActive(!entityData.IsActive);

        mapNameText.SetText(entityData.Name);
        mapImage.sprite = MapAvatarResolver.GetMapSprite(getCurrentEntity());

        mapInitialCurrencyText.SetText(entityData.initialCurrency.ToString());
        mapInitialHealthText.SetText(entityData.initialHealth.ToString());

        mapDescriptionText.SetText(entityData.description);


        foreach (Transform child in enemiesBar.transform)
        {
            Destroy(child.gameObject);
        }

        List<EnemyType> enemies = entityData.mapEnemies;
        List<EnemyDataModel> enemyDataModels = new List<EnemyDataModel>();

        foreach (var enemy in enemies)
        {
            var newEnemy = Instantiate(enemyUIPrefab, enemiesBar.transform, false);
            MapEnemyUIScript enemyUIScript = newEnemy.GetComponent<MapEnemyUIScript>();

            EnemyDataModel dataModel = EnemyDataModelResolver.getEnemyDataModel(enemy);
            Sprite avatar = EnemyAvatarResolver.GetEnemySprite(enemy);

            if (enemyUIScript != null)
            {
                enemyUIScript.Setup(dataModel.Name, avatar);
            }
        }
    }
}
