using UnityEngine;

public class ResearchCentreOutput : MonoBehaviour
{
    public int researchCentreOutput = 1;

    void Start()
    {
        InvokeRepeating("ProduceKnowledge", 0f, 2f);
    }

    void ProduceKnowledge()
    {
        if (transform.GetComponent<Rigidbody>().useGravity == false)
        {
            ResourceManager.knowledge += researchCentreOutput;
        }
    }
}
