using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float _attackRange = 10f;
    [SerializeField] protected float _attackRate = 1f;
    [SerializeField] protected int _damage = 10;
    [SerializeField] protected Transform _projectileSpawnPoint;

    protected float _nextAttackTime;
    protected Enemy _currentTarget;
    public bool isAcitive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAcitive)
        {
            return;
        }

        RotateHead();
        if (Time.time >= _nextAttackTime)
        {
        FindTarget();
        if (_currentTarget != null)
        {
            Attack();
            _nextAttackTime = Time.time + 1f / _attackRate;
        }
        }
        
    }

    protected virtual void FindTarget()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, _attackRange, LayerMask.GetMask("Enemy"));
        if (enemiesInRange.Length == 0)
        {
            _currentTarget = null;
            return;
        }
        float closestDistance = Mathf.Infinity;
        foreach (var enemyCollider in enemiesInRange)
        {
            float distance = Vector3.Distance(transform.position, enemyCollider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                // _currentTarget = enemyCollider.GetComponentInParent<Enemy>();
                _currentTarget = enemyCollider.transform.root.GetComponent<Enemy>();
            }
               
        }
    }

    protected abstract void Attack();   
    protected abstract void RotateHead();
}

// protected — это модификатор доступа, который означает, что переменная или метод:
// Виден внутри своего класса — как и private.
// Виден внутри всех классов-наследников (дочерних классов) — в отличие от private.
// Не виден для любого другого кода outside — как и private.

// virtual — это ключевое слово, которое означает, что метод может быть переопределен (modified) в классах-наследниках.
// Простыми словами:
// virtual в базовом классе говорит: "Это моя стандартная реализация метода FindTarget(), но если моим наследникам она не подходит, они могут заменить её своей собственной."
// override в классе-наследнике говорит: "Я использую свою собственную реализацию вместо стандартной."


// abstract — это ключевое слово, которое означает, что метод не имеет своей реализации (тела) в этом классе и должен быть обязательно переопределен (реализован) в классе-наследнике.
// Простыми словами:
// Класс с абстрактным методом говорит: "У всех моих наследников ДОЛЖЕН быть метод Attack(), но у каждого он будет свой. Я не знаю и не могу реализовать здесь общую версию."
// Ключевые особенности abstract:
// Нет реализации: У метода нет тела (фигурных скобок {}), только объявление. Вместо него ставится точка с запятой ;.
// Обязателен к переопределению: Если класс наследуется от абстрактного, он обязан реализовать все абстрактные методы с помощью override.
// Может быть только в абстрактном классе: Сам класс тоже должен быть помечен как abstract.
// Сравнение с virtual
// virtual: "Вот готовая реализация метода, но ты можешь её заменить, если захочешь." (Переопределение опционально).
// abstract: "Реализации нет. Ты ОБЯЗАН предоставить свою. Я тебе не помогу." (Переопределение обязательно).