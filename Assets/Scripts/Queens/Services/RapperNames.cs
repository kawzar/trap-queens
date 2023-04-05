using System.Collections.Generic;
using RandomGenerator.Scripts;

namespace Queens.Services
{
    public class RapperNames
    {
        public static readonly PartDefinition PrefijoNombre = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.MarkovOrItem,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "MC", "DJ", "Lil", "Big", "Rey", "Reina", "Fresco", "Joven", "Maestro", "Dama", "Mago",
                        "Máximo", "Dinero", "Estrella", "Ángel", "Supremo", "Rápido", "Brillante", "Poderoso", "Arma",
                        "Bravo", "Loco", "Genuino", "Original", "Mágico", "Fuerte", "Gigante", "Impactante", "Hábil",
                        "Duro", "Genial", "Estilo", "Épico", "Letal", "Explosivo", "Furioso", "Energético", "Intrépido",
                        "Increíble", "Audaz", "Valiente", "Respetado", "Sólido", "Innovador", "Real", "Verdadero",
                        "Héroe",
                        "Famoso", "Sensacional", "Victorioso", "Hábil", "Talentoso", "Brillante", "Estelar", "Vibrante",
                        "Prodigio", "Imponente", "Soberano", "Majestuoso", "Dominante", "Triunfador", "Supremo",
                        "Excepcional",
                        "Campeón", "Distinguido", "Experto", "Especial", "Imparable", "Mítico", "Glorioso", "Destacado",
                        "Legendario"
                    }
                }
            }
        );

        public static readonly PartDefinition SufijoNombre = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.Item,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "Flow", "Estilo", "Letras", "Ritmo", "Sonido", "Verso", "Batalla", "Magia", "Rimas", "Ruido",
                        "Ritmo", "Vibra", "Mente", "Poder", "Alma", "Luz", "Sabor", "Fuerza", "Fuego", "Valor",
                        "Gloria",
                        "Innovación", "Experiencia", "Pasión", "Emoción", "Técnica", "Expresión", "Inspiración",
                        "Originalidad",
                        "Calidad", "Creación", "Imaginación", "Locura", "Libertad", "Sueños", "Realidad", "Éxito",
                        "Historia",
                        "Revuelo", "Vanguardia", "Riqueza", "Riqueza", "Conexión", "Destino", "Aventura", "Conquista",
                        "Destreza", "Sabiduría", "Honor", "Virtuosismo", "Leyenda", "Furia", "Cambio"
                    }
                }
            }
        );
    }
}