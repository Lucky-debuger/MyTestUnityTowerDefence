public interface ISceneLoader // [ ] Why we need this interface?
{
    public void LoadLevel(string levelName);
    public void ReloadLevel(string sceneName);
    public void LoadMenu();
}