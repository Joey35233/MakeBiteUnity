using UnityEngine;
using UnityEditor;

public class MakeBiteWindow : EditorWindow
{
    struct MakeBiteMod
    {
        public string modName { private get; set; }
        public string modAuthor { private get; set; }
        public string modVersion { private get; set; }
        public string modGameVersion { private get; set; }
        public string modAuthor { private get; set; }
        string modDescription;
    }

    [MenuItem("MakeBite/Pack")]
    public static void ShowWindow()
    {
        GetWindow<MakeBiteWindow>("MakeBite");
    }

    void OnGUI()
    {
        MakeBiteMod makeBiteMod = new MakeBiteMod();

        GUILayout.Label("Mod information", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        makeBiteMod.modName = EditorGUILayout.DelayedTextField("Mod name", makeBiteMod.modName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        makeBiteMod.modAuthor = EditorGUILayout.TextField("Mod author", makeBiteMod.modAuthor);
        EditorGUILayout.EndHorizontal();
    }
}