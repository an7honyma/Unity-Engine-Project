using UnityEngine;
using UnityEngine.UI;

public class EnemyOutline : MonoBehaviour
{
    RaycastHit hit;
    public string enemyName;
    public Sprite enemyImage;

    void Update()
    {
        if (SelectedUnits.selectUnits)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50000f, (1 << 9)) || Physics.Raycast(ray, out hit, 50000f, (1 << 20)))
            {
                if (hit.transform.gameObject == gameObject && gameObject.GetComponent<EnemyHealth>().enemyHealth > 0)
                {
                    SelectedUnits.onEnemyUnit = true;
                    gameObject.GetComponent<Outline>().enabled = true;
                    EnemyIdentifier.enemyName = enemyName;
                    EnemyIdentifier.enemyImage = enemyImage;
                    EnemyIdentifier.enemyHealth = gameObject.GetComponent<EnemyHealth>().enemyHealth;
                }
            }
            else
            {
                SelectedUnits.onEnemyUnit = false;
                gameObject.GetComponent<Outline>().enabled = false;
                EnemyIdentifier.enemyName = null;
            }
        }
        else
        {
            SelectedUnits.onEnemyUnit = false;
            gameObject.GetComponent<Outline>().enabled = false;
            EnemyIdentifier.enemyName = null;
        }
    }
}
