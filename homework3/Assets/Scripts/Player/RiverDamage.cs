using Unity.VisualScripting;
using UnityEngine;

public class RiverDamage : MonoBehaviour
{
    public float riverDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterManager.Instance.Player.condition.uiCondition.health.Subtract(riverDamage);
            CharacterManager.Instance.Player.condition.uiCondition.thirst.Add(riverDamage * 15f);
        }
    }
}