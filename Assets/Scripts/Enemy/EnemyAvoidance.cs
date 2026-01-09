using UnityEngine;

public class EnemyAvoidance : MonoBehaviour // Проверить данный скрипт работате криво! Лучше потом передлать!
{
    [SerializeField] private float avoidanceRadius;
    [SerializeField] private float avoidanceForce;
    [SerializeField] LayerMask enemyLayer;

    // private void Update()
    // {
    //     CalculateAvoidanceCorrection();
    // } 

    public Vector3 CalculateAvoidanceCorrection()
    {
        Collider[] nearbyEnemies = Physics.OverlapSphere(
            transform.position,
            avoidanceRadius,
            enemyLayer
        );

        if (nearbyEnemies.Length == 1) return Vector3.zero;

        // Debug.Log(nearbyEnemies.Length);
        // for (var i = 1; i < nearbyEnemies.Length; i++)
        // {
        //     Debug.Log(i.name);
        // }

        Vector3 totalPush = Vector3.zero;
        int count = 0;

        foreach (Collider other in nearbyEnemies)
        {
            if (other.gameObject == gameObject) continue;

            Vector3 toOther = transform.position - other.transform.position; // toOther is a good name?
            float distance = toOther.magnitude; // Еще рза, что такое магнитуда?

            if (distance < avoidanceRadius && distance >= 0.1) // Нужно ли данное условие?
            {
                toOther.y = 0;
                toOther.Normalize();

                float strength = (avoidanceRadius - distance) / avoidanceRadius; // Разобраться с формулой
                totalPush += toOther * strength;
                count++;
            }
        }
        if (count > 0)
        {
            totalPush /= count;
            totalPush.y = 0;
            totalPush.Normalize();
            return totalPush * avoidanceForce;
        }

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, avoidanceRadius);    
    }
}
