using System;
using System.Collections.Generic;
using System.Linq;
using Queens.Models;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using UnityEngine;

namespace Queens.Services
{
    public static class CardParserService
    {
        public static List<Card> ParseCsv(string csv)
        {
            CsvReaderOptions options = new CsvReaderOptions(new[] { Environment.NewLine });
            CsvParserOptions parserOptions = new CsvParserOptions(true, ',');
            CsvCardMapping csvMapper = new CsvCardMapping();
            CsvParser<Card> csvParser = new CsvParser<Card>(parserOptions, csvMapper);

            var result = csvParser.ReadFromString(options, csv)
                .Select(x => x.Result)
                .ToList();

            return result;
        }
        
        public static List<Card> ParseJson(string json)
        {
            List<Card> result = new List<Card>();
            result = JsonUtility.FromJson<List<Card>>(json);
            return result;
        }
    }
    
    public class CsvCardMapping : CsvMapping<Card>
    {
        public CsvCardMapping() : base()
        {
            MapProperty(0, x => x.id);
            MapProperty(1, x => x.collection);
            MapProperty(2, x => x.bearer);
            MapProperty(3, x => x.name);
            MapProperty(4, x => x.level_lock);
            MapProperty(5, x => x.dialog);
            MapProperty(6, x => x.yes_answer);
            MapProperty(7, x => x.no_answer);
            MapProperty(8, x => x.yes_flow);
            MapProperty(9, x => x.yes_popularity);
            MapProperty(10, x => x.yes_money);
            MapProperty(11, x => x.yes_health);
            MapProperty(12, x => x.no_flow);
            MapProperty(13, x => x.no_popularity);
            MapProperty(14, x => x.no_money);
            MapProperty(15, x => x.no_health);
        }
    }
}
