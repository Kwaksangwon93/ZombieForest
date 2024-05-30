using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 2.5f;
    private float rotationSpeed = 100.0f;
    private Vector3 movementDirection;

    void Start()
    {
        SetRandomDirection();
        InvokeRepeating("SetRandomDirection", 2.0f, 2.0f);
    }

    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    void SetRandomDirection()
    {
        float randomYRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, randomYRotation, 0);
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        movementDirection = transform.forward;
    }
}
