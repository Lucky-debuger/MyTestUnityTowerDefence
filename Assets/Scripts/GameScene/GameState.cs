using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Game/GameState")]
public class GameState : ScriptableObject
{
    public string SelectedLevel { get; private set; }

    public void SetLevel(string levelName)
    {
        SelectedLevel = levelName;
    }
}
