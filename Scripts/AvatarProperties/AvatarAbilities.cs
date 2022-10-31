using UnityEngine;

public class AvatarAbilities : MonoBehaviour
{
    public GameObject playerInterface;
    public GameObject deployShieldButton;
    public GameObject deployShieldButtonBackground;
    public GameObject deployDroneButton;
    public GameObject deployDroneButtonBackground;
    public GameObject deployThrustersButton;
    public GameObject deployThrustersButtonBackground;
    public GameObject deployRepairStationButton;
    public GameObject deployRepairStationButtonBackground;
    public GameObject deployTractorBeamButton;
    public GameObject deployTractorBeamButtonBackground;

    public static int shieldLevel = 0;
    public static int droneLevel = 0;
    public static int thrustersLevel = 0;
    public static int repairStationLevel = 0;
    public static int tractorBeamLevel = 0;
    public static bool tractorBeamEnabled = false;

    public static void ShieldLevelUp()
    {
        shieldLevel ++;
    }

    public static void DroneLevelUp()
    {
        droneLevel ++;
    }

    public static void ThrustersLevelUp()
    {
        thrustersLevel ++;
    }

    public static void RepairStationLevelUp()
    {
        repairStationLevel ++;
    }

    public static void TractorBeamLevelUp()
    {
        tractorBeamLevel ++;
    }

    void Update()
    {
        if (playerInterface.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && deployShieldButtonBackground.activeSelf == true)
            {
                deployShieldButton.GetComponent<AvatarShieldButton>().DeployShield();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && deployDroneButtonBackground.activeSelf == true)
            {
                deployDroneButton.GetComponent<AvatarDroneButton>().DeployDrone();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && deployThrustersButtonBackground.activeSelf == true)
            {
                deployThrustersButton.GetComponent<AvatarThrustersButton>().DeployThrusters();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && deployRepairStationButtonBackground.activeSelf == true)
            {
                deployRepairStationButton.GetComponent<AvatarRepairStationButton>().DeployRepairStation();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && deployTractorBeamButtonBackground.activeSelf == true)
            {
                deployTractorBeamButton.GetComponent<AvatarTractorBeamButton>().DeployTractorBeam();
            }
        }
    }
}
