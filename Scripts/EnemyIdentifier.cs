using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyIdentifier : MonoBehaviour
{
    public static string enemyName;
    public static float enemyHealth;
    public static float enemyMaxHealth;
    public static Sprite enemyImage;

    public TextMeshProUGUI enemyNameField;
    public Image enemyImageField;
    public TextMeshProUGUI enemyHealthField;

    public GameObject enemyInfoPanel;

    void Update()
    {
        if (enemyName != null)
        {
            enemyNameField.text = enemyName;
            enemyImageField.sprite = enemyImage;
            enemyHealthField.text = enemyHealth.ToString();
            enemyInfoPanel.SetActive(true);
        }
        else
        {
            enemyInfoPanel.SetActive(false);
        }
    }
}
