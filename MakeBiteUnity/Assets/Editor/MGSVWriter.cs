using System;
using System.IO;
using System.Xml;
using makebite;
using SnakeBite;
//using FmdlStudio;

namespace UnityMakeBite
{
    public static class MGSVWriter
    {
        //The dataType string is temporary. Once FoxKit is in a state to be able to export data, this will be refactored to support that.
        public static void WriteMGSV(string modFilepath, string dataType, string prebuildPath, string buildPath, ModEntry modEntry)
        {
            switch (dataType)
            {
                case "Fmdl Studio V2":
                    Build.BuildArchive(prebuildPath, modEntry, buildPath);
                    break;
                case "FoxKit":
                    UnityEngine.Debug.Log("Error: FoxKit not yet supported.");
                    break;
                default:
                    UnityEngine.Debug.Log("Error: Invalid tool type selected");
                break;
            }
        }
    }
}