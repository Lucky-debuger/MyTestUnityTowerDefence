using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static float _money;
    private static int _lives;

    public static float Money => _money;
    public static int Lives => _lives;

    // Общая для всех экземпляров – Если у вас есть несколько объектов одного класса, static переменная будет одна на всех, а не у каждого своя.
    // Доступ без создания объекта – Её можно использовать, даже если не создан ни один экземпляр класса.
    // Живёт до конца программы – static переменная существует, пока работает приложение (в отличие от обычных переменных, которые удаляются, когда объект уничтожается).
    public int startMoney = 400;
    public int startLives = 20;

    public static event Action<float> OnMoneyChanged;
    public static event Action<float> OnLivesChanged;
    public static event Action OnLivesOver;

    public static void TryBuy(float money)
    {
        if (_money >= money)
        {
            _money -= money;
            OnMoneyChanged?.Invoke(_money);
        }
        else
        {
            Debug.Log("Don't enough money!");
        }
    }

    public static void DicreaseLives(int lives)
    {
        _lives -= lives;
        
        if (_lives <= 0)
        {
            OnLivesOver?.Invoke();
        }

        OnLivesChanged?.Invoke(_lives);
    }

    private void Start()
    {
        ResetLivesMoney();
    }

    public void ResetLivesMoney()
    {
        _lives = startLives;
        _money = startMoney;
        OnMoneyChanged?.Invoke(_money);
        OnLivesChanged?.Invoke(_lives);
    }
}
