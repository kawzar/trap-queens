using System;
using Queens.Models;
using RandomGenerator.Scripts.FantasyNameGenerators;
using UnityEngine;
using Random = System.Random;

namespace Queens.Services
{
    [CreateAssetMenu(fileName = "PlayerFactory")]
    public class PlayerFactory : ScriptableObject
    {
        public string FileName = "player.json";
        [Range(0, 100)] public int DefaultFlow = 25;
        [Range(0, 100)] public int DefaultPopularity = 25;
        [Range(0, 100)] public int DefaultHealth = 25;
        [Range(0, 100)] public int DefaultMoney = 25;

        private PlayerModel savedModel;

        private Random m_random;
        private readonly RapperNameGenerator _generator = new RapperNameGenerator();

        public PlayerModel GetSavedModel()
        {
            if (PlayerPrefs.HasKey(FileName))
            {
                string savedValue = PlayerPrefs.GetString(FileName);
                savedModel = PlayerParserService.ParseJson(savedValue)[0];
                if (!savedModel.status.IsValid())
                {
                    InitializeSavedModel();
                }
            }
            else
            {
                InitializeSavedModel();
            }

            return savedModel;
        }

        private void InitializeSavedModel()
        {
            savedModel = new PlayerModel();
            savedModel.status = new Status();
            savedModel.status.flow = DefaultFlow;
            savedModel.status.health = DefaultHealth;
            savedModel.status.popularity = DefaultPopularity;
            savedModel.status.money = DefaultMoney;
            m_random = new Random();
            savedModel.name = _generator.Generate(m_random);
        }
    }
}