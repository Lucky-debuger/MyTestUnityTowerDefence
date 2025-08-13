using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "CreateWave")]


public class Wave : ScriptableObject
{
    public GameObject enemy;
    public int count;
    public float rate;
}
