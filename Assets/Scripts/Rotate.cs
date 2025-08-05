using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public float speed = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        target.Rotate(0, 0, speed * Time.deltaTime);
    }
}
