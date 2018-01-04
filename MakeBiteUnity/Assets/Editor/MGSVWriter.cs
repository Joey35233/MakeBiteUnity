using System;
using System.IO;
using System.Xml;
using FmdlStudio;

namespace UnityMakeBite
{
    static class MGSVExporter
    {
        //The dataType string is temporary. Once FoxKit is in a state to be able to export data, this will be refactored to support that.
        public static void ExportMGSV(string filepath, string dataType, MakeBiteMod makeBiteMod)
        {
            if (dataType == "Fmdl Studio V2")
            {
                FmdlExporter.FMDLWrite(filepath);
            }
            else
            {
                UnityEngine.Debug.Log("How did you get here?");
            }
        }
    }
}
