using System;
using Newtonsoft.Json;

namespace HYPLAY.Runtime
{
    [Serializable]
    public class HyplayApp
    {
        public string id;
        public string secretKey;
        public string name;
        public string description;
        public string[] redirectUris;
        public string url;
        public HyplayImageAsset iconImageAsset;
        public HyplayImageAsset backgroundImageAsset;
    }

    [Serializable]
    public class HyplayUser
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("username")] 
        public string Username;
    }
}