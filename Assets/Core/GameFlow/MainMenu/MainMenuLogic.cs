using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject rulesPanel;
    public GameObject archivePanel;


    public void GoBackToMainPanel()
    {
        TogglePanels(mainPanel);
    }

    public void OpenRules()
    {
        TogglePanels(rulesPanel);
    }

    public void OpenArchive()
    {
        TogglePanels(archivePanel);
    }

    private void TogglePanels(GameObject panelToActivate)
    {
        mainPanel.SetActive(false);
        rulesPanel.SetActive(false);
        archivePanel.SetActive(false);

        panelToActivate.SetActive(true);
    }
}