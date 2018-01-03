
using System;
using System.IO;
using System.Xml;

namespace UnityMakeBite
{
    public static class MGSVWriter
    {
        //The dataType string is temporary. Once FoxKit is in a state to be able to export data, this will be refactored to support that.
        public static void WriteMGSV(string filepath, string dataType, MakeBiteMod makeBiteMod)
        {
            if (dataType == "Fmdl Studio V2")
            {
                
            }
            else
            {
                UnityEngine.Debug.Log("How did you get here?");
            }
        }
    }
}
