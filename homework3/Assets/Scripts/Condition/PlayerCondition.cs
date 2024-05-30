using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IDamagable
{
    void TakeDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;
    public Coroutine coroutine;

    Condition health { get { return uiCondition.health; } }
    Condition thirst { get { return uiCondition.thirst; } }

    public event Action onTakeDamage;

    private void Update()
    {
        health.Subtract(health.passiveValue * Time.deltaTime);
        thirst.Subtract(thirst.passiveValue * Time.deltaTime);

        if (thirst.curValue < 0)
        {
            health.Subtract(health.passiveValue * Time.deltaTime * 2f);
        }

        if (health.curValue == 0.0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void TakeDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            TakeDamage(10);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 50, ForceMode.Impulse);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * 3, ForceMode.Impulse);
            ZombieFollow zf = collision.gameObject.GetComponent<ZombieFollow>();
            if (zf != null)
            {
                if (coroutine != null)
                {
                    StopCoroutine(StopZombie(zf));
                }

                coroutine = StartCoroutine(StopZombie(zf));
            }
        }
    }

    IEnumerator StopZombie(ZombieFollow zf)
    {
        if (zf != null)
        {
            zf.baseSpeed = 0;
            yield return new WaitForSeconds(2.0f);
            zf.baseSpeed = 2.5f;
        }                
    }
}