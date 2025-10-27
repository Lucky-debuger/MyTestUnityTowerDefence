using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public static int Money;

    // Общая для всех экземпляров – Если у вас есть несколько объектов одного класса, static переменная будет одна на всех, а не у каждого своя.
    // Доступ без создания объекта – Её можно использовать, даже если не создан ни один экземпляр класса.
    // Живёт до конца программы – static переменная существует, пока работает приложение (в отличие от обычных переменных, которые удаляются, когда объект уничтожается).
    public int startMoney = 400;
    public int startLives = 20;

    void Start()
    {
        Lives = startLives;
        Money = startMoney;
    }
}
