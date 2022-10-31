using UnityEngine;

public class ArtifactTwo : MonoBehaviour
{

    public GameObject artifactFlash;

    void Start()
    {
        Destroy(gameObject, 60f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(artifactFlash, transform.position, transform.rotation);
        Destroy(gameObject);
        ResourceManager.artifactTwoCount ++;
        ResourceManager.UpdateResources();
    }
}