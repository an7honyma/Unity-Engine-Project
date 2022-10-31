using UnityEngine;

public class ShieldDuration : MonoBehaviour
{
    public float lifetime;
    private Transform parentTransform;

    void Start()
    {
        Destroy(gameObject, lifetime);
        parentTransform = transform.parent.gameObject.transform;
        transform.parent = null;
    }

    void LateUpdate()
    {
        transform.position = parentTransform.position;
    }
}
