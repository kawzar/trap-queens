using System.Collections.Generic;
using RandomGenerator.Scripts;

namespace Queens.Services
{
    public class RapperNameGenerator : Definition
    {
        public RapperNameGenerator()
        {
            Name = "Rapper";
            SupportedTypes = new[] { Gender.Neutral.ToString() };
            DefinitionFormats = new[]
            {
                new DefinitionFormat(
                    name: "Prefix Name",
                    formats: new[]
                    {
                        new Tuple<string, IEnumerable<PartDefinition>>("{0} {1}", new[]
                        {
                            RapperNames.PrefijoNombre,
                            RapperNames.SufijoNombre,
                        })
                    }
                )
            };
        }
    }
}