﻿using Trell.TwoDTestTask.Infrastructure.Service.Extension;
using UnityEngine;

namespace Trell.TwoDTestTask.Infrastructure.Service.Infrastructure.Saving
{
    public class SaveService : ISaveService
    {
        private readonly IPersistantPlayerProgressService _persistantPlayerProgressService;
        
        private const string Progress = "Progress";

        public SaveService(IPersistantPlayerProgressService persistantPlayerProgressService)
        {
            _persistantPlayerProgressService = persistantPlayerProgressService;
        }
        
        public SaveData Load() => 
            PlayerPrefs.GetString(Progress).ToDeserialize<SaveData>();

        public void Save() 
        {
            string json = _persistantPlayerProgressService.SaveData.ToJson();
            Debug.Log($"SaveData: \n {json}");
            PlayerPrefs.SetString(Progress, json);
        }
            
    }
}