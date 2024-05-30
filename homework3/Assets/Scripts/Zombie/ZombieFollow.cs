using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    public Transform player;
    public GameObject playerGameObject;
    public float detectionRange = 8f;
    public float baseSpeed = 2.5f;
    public float speedMultiplier = 1.2f;

    private bool isChasing = false;

    private void Start()
    {
        playerGameObject = GameObject.FindWithTag("Player");
        if(playerGameObject != null )
        {
            player = playerGameObject.GetComponent<Transform>();
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * (baseSpeed * speedMultiplier) * Time.deltaTime;
            transform.LookAt(player);
        }
        else
        {
            transform.Translate(Vector3.forward * baseSpeed * Time.deltaTime);
        }
    }
}
