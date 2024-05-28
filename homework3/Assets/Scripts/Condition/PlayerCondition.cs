using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
    void brokenLeg(float hurt);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }

    public event Action onTakeDamage;
    public event Action onFallDamage;

    private void Update()
    {
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
        //SceneManager.LoadScene("ReplayScene");
    }

    public void brokenLeg(float hurt)
    {
        health.Subtract(hurt);
        onFallDamage?.Invoke("OnJump", 0.1f);
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}