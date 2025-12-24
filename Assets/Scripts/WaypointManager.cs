using UnityEngine;
using System.Collections.Generic;


public class WaypointManager : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();
    public bool isMoving;
    public bool isLoop;
    public int waypointIndex;

    [Header("Movement Settings")]
    public float baseMoveSpeed;
    public float rotationSpeed;

    [Header("Avoidance Settings")]
    [SerializeField] private float avoidanceWeight; // Насколько сильно избегание влияет
    [SerializeField] private EnemyAvoidance enemyAvoidance;
    
    private float _slowMultiplier = 1f;
    private float _currentMoveSpeed;
    private float _slowDuration = 0f;


    void Start()
    {
        GameObject parentWayPoints = GameObject.Find("WayPoints");
        for (int i = 0; i < parentWayPoints.transform.childCount; i++)
        {
            wayPoints.Add(parentWayPoints.transform.GetChild(i).GetComponent<Transform>());
        }
        StartMoving();
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;

        Vector3 waypointDirection = GetWaypointDirection();

        Vector3 avoidanceCorrection = enemyAvoidance != null
        ? enemyAvoidance.CalculateAvoidanceCorrection()
        : Vector3.zero;
        
        Vector3 finalDirection = waypointDirection  + (avoidanceCorrection * avoidanceWeight); // Что такое вес и почему он так называется?
        Debug.Log(avoidanceCorrection);
        // if (finalDirection.magnitude > 0.1f) // Что это и зачем?
        // {
        _currentMoveSpeed = CalculateCurrentSpeed();
        finalDirection.Normalize();
        Vector3 movement = finalDirection * _currentMoveSpeed * Time.fixedDeltaTime;

        // rb.MovePosition(rb.position + movement); // Почему тут написано через + 
        transform.position += movement;
        RotateTowards(finalDirection);
        // }

        CheckWaypointReached();
    }

    private Vector3 GetWaypointDirection()
    {
        if (waypointIndex >= wayPoints.Count) return Vector3.zero;

        Vector3 direction = wayPoints[waypointIndex].position - transform.position; // Как понять, что от чего отнимать
        return direction.normalized;
    }

    private float CalculateCurrentSpeed()
    {
        if (_slowDuration > 0f)
        {
            _slowDuration -= Time.fixedDeltaTime; // что такое capture?
            if (_slowDuration <= 0) RemoveSlow();
        }

        return baseMoveSpeed * _slowMultiplier;
    }

    private void RotateTowards(Vector3 direction)
    {
        if (direction.magnitude < 0.1f) return;

        Quaternion targetRotation = Quaternion.LookRotation(-direction, Vector3.up); // Нужно ли указывать верх? Зачем теперь тут минус?
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            Time.fixedDeltaTime * rotationSpeed // Почему тут тоже fixedDeltaTime?
        );
    }

    private void CheckWaypointReached()
    {
        
        var distance = Vector3.Distance(transform.position, wayPoints[waypointIndex].position);
        
        if (distance <= 0.4f)
        {
            waypointIndex++;
            Debug.Log(waypointIndex);

            if (isLoop && waypointIndex >= wayPoints.Count)
            {
                waypointIndex = 0;
            }
            else if (!isLoop && waypointIndex >= wayPoints.Count)
            {
                EndPath();
                return;
            }
        }
    }


    // void Update()
    // {
    //     if (!isMoving)
    //     {
    //         return;
    //     }

    //     if (_slowDuration > 0)
    //     {
    //         _slowDuration -= Time.deltaTime;
    //         if (_slowDuration <= 0)
    //         {
    //             RemoveSlow();
    //         }
    //     }

    //     if (waypointIndex < wayPoints.Count)
    //     {
    //         UpdateCurrentSpeed();
    //         transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointIndex].position, Time.deltaTime * _currentMoveSpeed);

    //         var direction = transform.position - wayPoints[waypointIndex].position;
    //         var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    //         var distance = Vector3.Distance(transform.position, wayPoints[waypointIndex].position);
    //         if (distance <= 0.05f)
    //         {
    //             waypointIndex++;

    //             if (isLoop && waypointIndex >= wayPoints.Count)
    //             {
    //                 waypointIndex = 0;
    //             }
    //             else if (!isLoop && waypointIndex >= wayPoints.Count)
    //             {
    //                 EndPath();
    //                 return;
    //             }
    //         }
    //     }

    // }
    public void StartMoving()
    {
        waypointIndex = 0;
        isMoving = true;
        UpdateCurrentSpeed();
    }

    public void EndPath()
    {
        PlayerStats.Lives--;
        gameObject.GetComponent<Enemy>().Die();
    }

    public void ApplySlow(float slowPercentage, float duration)
    {
        _slowMultiplier = 1f - Mathf.Clamp01(slowPercentage);
        _slowDuration = duration;
    }

    public void RemoveSlow()
    {
        _slowMultiplier = 1f;
        _slowDuration = 0f;
    }

    private void UpdateCurrentSpeed()
    {
        _currentMoveSpeed = baseMoveSpeed * _slowMultiplier;
    }
}
