using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Game/GameState")]
public class GameState : ScriptableObject
{
    public string selectedLevel { get; private set; }

    public void SetLevel(string levelName)
    {
        selectedLevel = levelName;
    }
}
