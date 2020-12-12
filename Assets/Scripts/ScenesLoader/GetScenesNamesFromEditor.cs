using UnityEngine;
using UnityEditor;
public class GetScenesNamesFromEditor
{
    [MenuItem("Scenes Names/Save Scenes Names")]
    private static void SaveScenesNames()
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

        // First, try to load the list if already exists
        ScenesList list = (ScenesList)AssetDatabase.LoadAssetAtPath("Assets/Resources/ScenesList.asset", typeof(ScenesList));

        // If doesn't exist, create it !
        if (list == null)
        {
            list = ScriptableObject.CreateInstance<ScenesList>();
            AssetDatabase.CreateAsset(list, "Assets/Resources/ScenesList.asset");
        }

        // Fill the array
        list.scenesNames = new string[scenes.Length];
        for (int i = 0; i < scenes.Length; ++i )
     {
            list.scenesNames[i] = scenes[i].path;
        }

        // Writes all unsaved asset changes to disk
        AssetDatabase.SaveAssets();
    }
}