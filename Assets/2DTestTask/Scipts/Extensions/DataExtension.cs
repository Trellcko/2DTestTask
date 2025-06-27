using Trell.TwoDTestTask.Infrastructure.Saving;
using UnityEngine;

namespace Trell.TwoDTestTask.Extra
{
    public static class DataExtension
    {
        public static T ToDeserialize<T>(this string data) where T : class, new() => 
            JsonUtility.FromJson<T>(data);
        
        public static string ToJson<T>(this T data) where T : class, new() =>
        JsonUtility.ToJson(data);
    }
}