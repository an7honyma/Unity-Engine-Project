using UnityEngine;

public class RefineryOutput : MonoBehaviour
{
    public float refineryOutput = 1f;

    void Start()
    {
        InvokeRepeating("ProduceCredits", 0f, 0.2f);
    }

    void ProduceCredits()
    {
        if (gameObject.tag == "EnemyTarget")
        {
            if (ResourceManager.excessPower > 0)
            {
                ResourceManager.credits += refineryOutput;
            }
            else if (ResourceManager.excessPower <= 0)
            {
                ResourceManager.credits += refineryOutput/2;
                NotificationManager.insufficientPower = true;
            }
        }
    }
}
