using UnityEngine;
using UnityEditor;

namespace UnityMakeBite
{
    public class MakeBiteWindow : EditorWindow
    {
        private MakeBiteMod makeBiteMod = new MakeBiteMod();

        string[] gameVersionList = new string[1] { "1.0.12" };
        int gameVersonIndex = 0;

        //These will only last until FoxKit is able to export data
        string[] dataTypeList = new string[2] { "Fmdl Studio V2", "FoxKit" };
        int dataTypeIndex = 0;
        string dataType;

        string filepath;

        [MenuItem("MakeBite/Pack")]
        private static void ShowWindow()
        {
            GetWindow<MakeBiteWindow>("MakeBite");
        }

        private void OnGUI()
        {
            GUILayout.Label("Export Type - Temporary", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            dataTypeIndex = EditorGUILayout.Popup("Tool", dataTypeIndex, dataTypeList);

            if (dataTypeIndex == 0)
            {
                dataType = dataTypeList[dataTypeIndex];
            }

            else
            {
                dataTypeIndex = 0;
                UnityEngine.Debug.Log("Fox Kit does not yet support exporting. Switching to Fmdl Studio V2...");
            }

            EditorGUILayout.EndHorizontal();

            GUILayout.Label("Mod Information", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            makeBiteMod.modName = EditorGUILayout.DelayedTextField("Mod Name", makeBiteMod.modName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            makeBiteMod.modAuthor = EditorGUILayout.TextField("Mod Author", makeBiteMod.modAuthor);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            makeBiteMod.modVersion = EditorGUILayout.TextField("Mod Version", makeBiteMod.modVersion);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            gameVersonIndex = EditorGUILayout.Popup("Game Version", gameVersonIndex, gameVersionList);
            makeBiteMod.modGameVersion = gameVersionList[gameVersonIndex];
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            makeBiteMod.modAuthorWebsite = EditorGUILayout.TextField("Author's Website", makeBiteMod.modAuthorWebsite);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            makeBiteMod.modDescription = EditorGUILayout.TextField("Mod Description", makeBiteMod.modDescription);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            GUILayout.Label("Asset Information", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            if (GUILayout.Button("Filepath"))
            {
                filepath = EditorUtility.OpenFolderPanel("Choose asset path", @"", "");
            }

            EditorGUILayout.BeginHorizontal();
            filepath = EditorGUILayout.TextField(filepath);
            EditorGUILayout.EndHorizontal();

            //EditorGUILayout.BeginHorizontal();
            //makeBiteMod.modFolder = EditorGUILayout.TextField("Mod Folder", makeBiteMod.modFolder);
            //EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            if (GUILayout.Button("Pack .mgsv"))
            {
                string mgsvPath = EditorUtility.SaveFilePanel("Choose .mgsv save location", filepath, makeBiteMod.modName, "mgsv");
                MGSVExporter.ExportMGSV(filepath, dataType, makeBiteMod);
            }
        }
    }
}