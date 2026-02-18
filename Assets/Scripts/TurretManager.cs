using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private readonly List<GameObject> _turrets = new List<GameObject>();

    public void RegisterTurret(GameObject turret)
    {
        _turrets.Add(turret);
    }

    public void UnregisterTurret(GameObject turret)
    {
        _turrets.Remove(turret);
    }

    public IReadOnlyList<GameObject> Turrets => _turrets;
}
