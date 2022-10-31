using UnityEngine;

public class BulldozePanel : MonoBehaviour
{
    public void Bulldoze()
    {
        Destroy(BuildToggle.buildingToDelete);
        BuildToggle.buildingToDelete = null;
        BuildToggle.buildingToDeleteName = null;
        BuildToggle.buildingToDeleteImage = null;
        BuildToggle.onProductionMenu = false;
    }

    public void CancelBulldoze()
    {
        BuildToggle.buildingToDelete = null;
        BuildToggle.buildingToDeleteName = null;
        BuildToggle.buildingToDeleteImage = null;
    }
}
