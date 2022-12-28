using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    public static Health instance;

    public event Action OnValueChanged, OnDie;

    [SerializeField] int _maxHealth;

    Stat _health;
    bool _alive;

    void Awake()
    {
        instance = this;
        _health = new Stat(_maxHealth);
    }

    void Start()
    {

        _alive = true;
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);

        OnValueChanged.Invoke();

        if (_health.Get() == 0)
            _alive = false;

        Die();
    }

    public void Heal(int value)
    {
        _health.Increase(value);

        OnValueChanged.Invoke();
    }

    public float Get()
    {
        return _health.Get();
    }

    public float GetMax()
    {
        return _health.GetMax();
    }

    void Die()
    {
        if (!_alive)
        {
            OnDie.Invoke();
        }
    }


}
