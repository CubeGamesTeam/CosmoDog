using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CGS.Editor
{
    [InitializeOnLoad]
    public static class MainSceneAutoLoader
    {
        private const string STARTING_SCENE_PATH = "Assets/Scenes/0Init.unity";
        private const string PREF_KEY_PREV_SCENE = "PREVIOUS SCENE";

        static MainSceneAutoLoader()
            => EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (EditorApplication.isPlaying)
                return;

            if (SceneManager.GetActiveScene().buildIndex == -1)
                return;
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                OpenStartingScene();
            else
                OpenLastLoadedScene();
        }

        private static void OpenStartingScene()
        {
            string path = SceneManager.GetActiveScene().path;
            EditorPrefs.SetString(PREF_KEY_PREV_SCENE, path);
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorApplication.isPlaying = false;
                return;
            }

            if (path != STARTING_SCENE_PATH
                && !OpenScene(STARTING_SCENE_PATH))
                EditorApplication.isPlaying = false;
        }

        private static void OpenLastLoadedScene()
        {
            string path = EditorPrefs.GetString(PREF_KEY_PREV_SCENE);
            if (string.IsNullOrEmpty(path))
                path = STARTING_SCENE_PATH;
            if (path != SceneManager.GetActiveScene().path)
                OpenScene(path);
        }

        private static bool OpenScene(string path)
        {
            try
            {
                EditorSceneManager.OpenScene(path);
            }
            catch
            {
                #if UNITY_EDITOR
                    Debug.LogError($"Could not load scene: {path}");
                #endif
                return false;
            }

            return true;
        }
    }
}