using System;
using System.Collections.Generic;
using System.Text;

namespace SoundOff
{
    internal class PresetListClass
    {
        Dictionary<int, string> keyValuePairs = new Dictionary<int, string>() 
        {
            { 0, "" },
            { 1, "" },
            { 2, "" },
            { 3, "" },
            { 4, "" },
            { 5, "" },
            { 6, "" },
            { 7, "" },
            { 8, "" }
        };

        public PresetListClass()
        {
            // Initialize the dictionary with default values if needed
        }
    }
}
