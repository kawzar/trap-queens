using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Queens.Models;
using Queens.ViewModels;
using UnityEngine;

namespace Queens.Services
{
    [CreateAssetMenu]

    public class HistoricDataFactory : ScriptableObject
    {
        public string FilePath = Application.streamingAssetsPath;
        public string FileName = "historic.json";

        private List<HistoricPlayerModel> savedModel;
        
        public List<HistoricPlayerModel> GetHistoricData()
        {
            if(savedModel != null) return savedModel;
            
            var path = Path.Combine(FilePath, FileName);
            if (File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                savedModel = JsonConvert.DeserializeObject<List<HistoricPlayerModel>>(string.Join(Environment.NewLine, lines));
            }
            else
            {
                savedModel = new List<HistoricPlayerModel>();
            }

            return savedModel;
        }

        public void AddHistoricData(PlayerViewModel vm)
        {
            savedModel.Add(new HistoricPlayerModel(vm.Career, vm.Name));
            var path = Path.Combine(FilePath, FileName);
            File.WriteAllText(path, JsonConvert.SerializeObject(savedModel));
        }
    }
}