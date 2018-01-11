using UnityEngine;
using UnityEditor;
using SnakeBite;

namespace UnityMakeBite
{
    public class MakeBiteWindow : EditorWindow
    {
        private ModEntry modEntry = new ModEntry();

        string[] gameVersionList = new string[1] { "1.0.12" };
        int gameVersonIndex = 0;

        //These will only last until FoxKit is able to export data
        string[] dataTypeList = new string[2] { "Fmdl Studio V2", "FoxKit" };
        int dataTypeIndex = 0;
        string dataType;

        string[] fmdlList = new string[1] { "Venom - Fatigues" };
        string[] fmdlPathList = new string[1] { "/Assets/tpp/pack/player/parts/normal_venom/assets/tpp/pack/chara/sna/sna0_main0_def.fmdl" };
        int fmdlIndex = 0;

        bool usePreset = true;

        string modFilepath;
        string fmdlFilepath;

        bool usePack = true;

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
            dataType = dataTypeList[dataTypeIndex];
            EditorGUILayout.EndHorizontal();

            GUILayout.Label("Mod Information", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            modEntry.Name = EditorGUILayout.DelayedTextField("Mod Name", modEntry.Name);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            modEntry.Author = EditorGUILayout.TextField("Mod Author", modEntry.Author);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            modEntry.Version = EditorGUILayout.TextField("Mod Version", modEntry.Version);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            gameVersonIndex = EditorGUILayout.Popup("Game Version", gameVersonIndex, gameVersionList);
            modEntry.MGSVersion.Version = gameVersionList[gameVersonIndex];
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            modEntry.Website = EditorGUILayout.TextField("Author's Website", modEntry.Website);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            modEntry.Description = EditorGUILayout.TextField("Mod Description", modEntry.Description);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            GUILayout.Label("Asset Information", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            switch (dataType)
            {
                case "Fmdl Studio V2":
                    if (GUILayout.Button("Filepath"))
                    {
                        modFilepath = EditorUtility.OpenFolderPanel("Choose asset path", @"", "");
                    }

                    EditorGUILayout.BeginHorizontal();
                    modFilepath = EditorGUILayout.TextField(modFilepath);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.Space();

                    EditorGUILayout.BeginHorizontal();
                    usePreset = EditorGUILayout.Toggle("Use Preset", usePreset);

                    using (new EditorGUI.DisabledScope(usePreset == false))
                    {
                        fmdlIndex = EditorGUILayout.Popup(fmdlIndex, fmdlList);
                        fmdlFilepath = fmdlPathList[fmdlIndex];
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    using (new EditorGUI.DisabledScope(usePreset == true))
                    {
                        fmdlFilepath = EditorGUILayout.TextField(fmdlFilepath);
                    }
                    EditorGUILayout.EndHorizontal();

                    usePack = true;
                    break;

                case "FoxKit":
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label("FoxKit not yet supported");
                    EditorGUILayout.EndHorizontal();

                    usePack = false;
                    break;
                default:
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label("Tool type not selected");
                    EditorGUILayout.EndHorizontal();

                    usePack = false;
                    break;
            }

            using (new EditorGUI.DisabledScope(usePack == false))
            {
                EditorGUILayout.Space();

                if (GUILayout.Button("Pack .mgsv"))
                {
                    string buildPath = EditorUtility.SaveFilePanel("Choose .mgsv save location", modFilepath, modEntry.Name, "mgsv");
                    const string prebuildPath = @"\PreBuild";

                    MGSVWriter.WriteMGSV(modFilepath, dataType, prebuildPath, buildPath, modEntry);
                }
            }
        }
    }
}