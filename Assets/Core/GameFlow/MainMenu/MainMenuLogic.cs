using System.Collections.Generic;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject rulesPanel;
    public GameObject knowledgeBaseChoicePanel;

    public GameObject arsenalPanel;
    public GameObject enemiesPanel;
    public GameObject mapsPanel;

    public List<GameObject> allPanels;

    private void Start()
    {

        allPanels = new List<GameObject>
        {
            mainPanel,
            rulesPanel,
            knowledgeBaseChoicePanel,
            arsenalPanel,
            enemiesPanel,
            mapsPanel
        };
    }

    public void GoBackToMainPanel()
    {
        TogglePanels(mainPanel);
    }

    public void OpenRules()
    {
        TogglePanels(rulesPanel);
    }

    public void OpenKnowledgeBaseChoicePanel()
    {
        TogglePanels(knowledgeBaseChoicePanel);
    }

    public void OpenEnemiesPanel()
    {
        TogglePanels(enemiesPanel);
    }

    public void OpenArsenalPanel()
    {
        TogglePanels(arsenalPanel);
    }

    public void OpenMapsPanel()
    {
        TogglePanels(mapsPanel);
    }

    private void TogglePanels(GameObject panelToActivate)
    {
        foreach (var item in allPanels)
        {
            item.SetActive(false);
        }

        panelToActivate.SetActive(true);
    }
}