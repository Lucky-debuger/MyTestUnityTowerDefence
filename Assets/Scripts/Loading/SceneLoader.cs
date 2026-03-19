using UnityEngine.SceneManagement;

namespace Loading
{
    public static class LoadingSceneLoader
    {
        /// <summary>
        /// Loading only Loading Scene
        /// </summary>
        public static void LoadLoadingScene()
        {
            SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
        }
    }
}
