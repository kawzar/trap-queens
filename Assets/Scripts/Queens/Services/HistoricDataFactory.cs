using System.Collections.Generic;
using Newtonsoft.Json;
using Queens.Models;
using Queens.ViewModels;
using UnityEngine;

namespace Queens.Services
{
    [CreateAssetMenu]

    public class HistoricDataFactory : ScriptableObject
    {
        public string FileName = "historic.json";

        private List<HistoricPlayerModel> savedModel;
        
        public List<HistoricPlayerModel> GetHistoricData()
        {
            if(savedModel != null) return savedModel;

            if (PlayerPrefs.HasKey(FileName))
            {
                var savedText = PlayerPrefs.GetString(FileName);
                savedModel = JsonConvert.DeserializeObject<List<HistoricPlayerModel>>(savedText);
            }
            else
            {
                savedModel = new List<HistoricPlayerModel>();
            }

            return savedModel;
        }

        public void AddHistoricData(PlayerViewModel vm)
        {
            if (savedModel == null)
            {
                savedModel = new List<HistoricPlayerModel>();
            }
            savedModel.Add(new HistoricPlayerModel(vm.Career, vm.Name));
            PlayerPrefs.SetString(FileName, JsonConvert.SerializeObject(savedModel));
            PlayerPrefs.Save();
        }
    }
}