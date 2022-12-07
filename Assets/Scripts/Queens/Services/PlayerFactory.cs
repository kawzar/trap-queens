using System;
using System.IO;
using Queens.Models;
using RandomGenerator.Scripts.FantasyNameGenerators;
using UnityEngine;
using Random = System.Random;

namespace Queens.Services
{
    [CreateAssetMenu(fileName = "PlayerFactory")]
    public class PlayerFactory : ScriptableObject
    {
        public string FilePath = Application.streamingAssetsPath;
        public string FileName = "player.json";
        [Range(0, 100)] public int DefaultFlow = 25;
        [Range(0, 100)] public int DefaultPopularity = 25;
        [Range(0, 100)] public int DefaultHealth = 25;
        [Range(0, 100)] public int DefaultMoney = 25;

        private PlayerModel savedModel;

        private Random m_random = new Random();
        private readonly HumanNameGenerator _generator = new HumanNameGenerator();

        public PlayerModel GetSavedModel()
        {
            if(savedModel != null) return savedModel;
               
            var path = Path.Combine(FilePath, FileName);
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                savedModel = PlayerParserService.ParseJson(string.Join(Environment.NewLine, lines))[0];
            }
            else
            {
                savedModel = new PlayerModel();
                savedModel.status = new Status();
                savedModel.status.flow = DefaultFlow;
                savedModel.status.health = DefaultHealth;
                savedModel.status.popularity = DefaultPopularity;
                savedModel.status.money = DefaultMoney;
                savedModel.name = _generator.Generate(m_random);
                Debug.Log(savedModel.name);
            }

            return savedModel;
        }
    }
}