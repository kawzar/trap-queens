using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Queens.Models;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace Queens.Services
{
    public static class CardParserService
    {
        public static List<CardModel> ParseCsv(string csv)
        {
            CsvReaderOptions options = new CsvReaderOptions(new[] { Environment.NewLine });
            CsvParserOptions parserOptions = new CsvParserOptions(true, ',');
            CsvCardMapping csvMapper = new CsvCardMapping();
            CsvParser<CardModel> csvParser = new CsvParser<CardModel>(parserOptions, csvMapper);

            var result = csvParser.ReadFromString(options, csv)
                .Select(x => x.Result)
                .ToList();

            return result;
        }

        public static List<CardModel> ParseJson(string json)
        {
            return JsonConvert.DeserializeObject<List<CardModel>>(json);
        }
    }
    
    public class CsvCardMapping : CsvMapping<CardModel>
    {
        public CsvCardMapping() : base()
        {
            MapProperty(0, x => x.id);
            MapProperty(1, x => x.collection);
            MapProperty(2, x => x.bearer);
            MapProperty(3, x => x.name);
            MapProperty(4, x => x.level_lock);
            MapProperty(5, x => x.dialog);
            MapProperty(6, x => x.yes_flow);
            MapProperty(7, x => x.yes_popularity);
            MapProperty(8, x => x.yes_money);
            MapProperty(9, x => x.yes_health);
            MapProperty(10, x => x.no_flow);
            MapProperty(11, x => x.no_popularity);
            MapProperty(12, x => x.no_money);
            MapProperty(13, x => x.no_health);
        }
    }
}
