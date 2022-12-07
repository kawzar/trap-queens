using System.Collections.Generic;
using Newtonsoft.Json;
using Queens.Models;
using Queens.ViewModels;

namespace Queens.Services
{
    public static class PlayerParserService
    {
        public static List<PlayerModel> ParseJson(string json)
        {
            return JsonConvert.DeserializeObject<List<PlayerModel>>(json);
        }

        public static string ToJson(PlayerViewModel viewModel)
        {
            PlayerModel model = new PlayerModel();
            model.status = new Status();
            model.active_collections = viewModel.ActiveCollections;
            model.status.flow = viewModel.Stats.Flow;
            model.status.health = viewModel.Stats.Health;
            model.status.money = viewModel.Stats.Money;
            model.status.popularity = viewModel.Stats.Popularity;
            model.career = viewModel.Career;
            model.name = viewModel.Name;

            return JsonConvert.SerializeObject(model);
        }
    }
}