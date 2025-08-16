using UnityEngine;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();
    public bool isMoving;
    public bool isLoop;
    public int waypointIndex;
    public int moveSpeed;
    public float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject parentWayPoints = GameObject.Find("WayPoints");
        for (int i = 0; i < parentWayPoints.transform.childCount; i++)
        {
            wayPoints.Add(parentWayPoints.transform.GetChild(i).GetComponent<Transform>());
        }
        StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        if (waypointIndex < wayPoints.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointIndex].position, Time.deltaTime * moveSpeed);

            var direction = transform.position - wayPoints[waypointIndex].position;
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            var distance = Vector3.Distance(transform.position, wayPoints[waypointIndex].position);
            if (distance <= 0.05f)
            {
                waypointIndex++;

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

    }
    public void StartMoving()
    {
        waypointIndex = 0;
        isMoving = true;
    }

    public void EndPath()
    {
        PlayerStats.Lives--;
        gameObject.GetComponent<Enemy>().Die();
    }
}
