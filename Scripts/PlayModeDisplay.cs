using UnityEngine;
using TMPro;

public class PlayModeDisplay : MonoBehaviour
{
    public TextMeshProUGUI playMode;

    void Start()
    {
        playMode.text = "Action";
    }

    void Update()
    {
        if (SelectedUnits.selectUnits)
        {
            playMode.text = "Unit Selection";
        }
        else if (BuildToggle.isBuilding)
        {
            playMode.text = "Construction";
        }
        else
        {
            playMode.text = "Action";
        }
    }
}
