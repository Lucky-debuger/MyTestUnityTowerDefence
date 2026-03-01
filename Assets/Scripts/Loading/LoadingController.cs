using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Loading
{
    public class LoadingController : MonoBehaviour
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private GameState gameState;

        private async void Start()
        {
            string targetScene = gameState.SelectedLevel;

            await UnloadPreviousLevel();

            AsyncOperation op = SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);
            op.allowSceneActivation = false;

            while (op.progress < 0.9f) 
            {
                progressBar.value = op.progress;
                // await Task.Yield();
                await Task.Delay(1000);
            }

            progressBar.value = 1.0f;

            op.allowSceneActivation = true;

            await Task.Yield(); // [ ] for what?

            await SceneManager.UnloadSceneAsync("Loading"); // [ ] Do we need here await?
        }

        private async Task UnloadPreviousLevel() // [ ] for what? Can we optimize it?
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene s = SceneManager.GetSceneAt(i);

                if (s.name != "Game" && s.name != "Loading")
                {
                    await SceneManager.UnloadSceneAsync(s);
                }
            }
        }
    }
}
