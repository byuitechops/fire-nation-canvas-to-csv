using Newtonsoft.Json.Linq;

namespace Wololo
{
    class In
    {
        // Convert CSV file to JArray
        internal static JArray jarrFromCSVFile(string path)
        {
            
        }

        // Convert HTTP url request to JArray
        internal static JArray jarrFromURL(string url)
        {

        }


        // Convert JSON file to JArray 
        internal static JArray jarrFromJSONFile(string path)
        {

        }

        // Convert C# OBJ to JArray 
        internal static JArray jarrFromObj(Object obj)
        {
            JArray jarr = new JArray();
            return jarr.FromObject(o);
        }
     
        
    }
}