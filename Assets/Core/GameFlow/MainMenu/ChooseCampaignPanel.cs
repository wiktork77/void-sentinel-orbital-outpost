using UnityEngine;
using UnityEngine.UI;

public class ChooseCampaignPanel : MonoBehaviour
{
    public GameObject AresBlockScreen;
    public GameObject GlaciesBlockScreen;
    public GameObject XenoBlockScreen;

    public Button AresScreen;
    public Button GlaciesScreen;
    public Button XenoScreen;

    void Start()
    {
        bool aresCompleted = GlobalGameState.GetMapCompletionStatus(MapType.ARES);

        GlaciesBlockScreen.SetActive(!aresCompleted);
        GlaciesScreen.interactable = aresCompleted;

        XenoScreen.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
