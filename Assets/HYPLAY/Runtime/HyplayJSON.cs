#if NEWTONSOFT_JSON
using Newtonsoft.Json;
#endif
using UnityEngine;

namespace HYPLAY.Runtime
{
    public static class HyplayJSON
    {
        public static T Deserialize<T>(string json)
        {
            #if NEWTONSOFT_JSON
            return JsonConvert.DeserializeObject<T>(json);
            #endif
            
            #if UNITY_EDITOR
            InstallPackage();
            #endif
            Debug.LogWarning("Newtonsoft JSON not installed");
            return default;
        }

        public static string Serialize(object obj)
        {
            #if NEWTONSOFT_JSON
            return JsonConvert.SerializeObject(obj);
            #endif
            
            #if UNITY_EDITOR
            InstallPackage();
            #endif
            Debug.LogWarning("Newtonsoft JSON not installed");
            return default;
        }
        
        #if UNITY_EDITOR
        public static void InstallPackage()
        {
            if (UnityEditor.EditorApplication.isPlaying)
                UnityEditor.EditorApplication.ExitPlaymode();
            
            UnityEditor.PackageManager.Client.Add("com.unity.nuget.newtonsoft-json");
        }
        #endif
    }
}