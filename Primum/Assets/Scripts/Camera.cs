using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform objectToFollow;
    [SerializeField] private float followSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectToFollow = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(objectToFollow.position.x, objectToFollow.position.y, -16f);
        transform.position = pos;
    }
}
