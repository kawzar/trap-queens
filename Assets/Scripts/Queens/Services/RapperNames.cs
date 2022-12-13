﻿using System.Collections.Generic;
using RandomGenerator.Scripts;

namespace Queens.Services
{
    public class RapperNames
    {
        public static readonly PartDefinition NamePrefix = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.MarkovOrItem,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "lil", "big", "monster", "kid", "fresh", "queen", "king", "mc", "lit"
                    }
                }
            }
        );

        public static readonly PartDefinition NameSuffix = new PartDefinition
        (
            markovOrder: 2,
            mode: Mode.Item,
            source: new Dictionary<string, string[]>(1)
            {
                {
                    "Neutral", new[]
                    {
                        "grande", "pequeño", "alto", "bajo", "gordo", "flaco", "ancho", "largo", "estrecho", "fino",
                        "grueso", "delicado", "grotesco", "inteligente", "tonto", "hábil", "torpe", "culto",
                        "ignorante", "limpio", "sucio", "frío", "caliente", "tibio", "cálido", "helado", "espontáneo",
                        "simple", "complicado", "sencillo", "amable", "gentil", "rudo", "bruto", "astuto", "ingenuo",
                        "humilde", "modesto", "presumido", "altanero", "curioso", "apático", "bello", "hermoso", "feo",
                        "horrible", "agradable", "desagradable", "lento", "veloz", "rápido", "regio", "maduro",
                        "inmaduro", "dulce", "amargo", "ácido", "salado", "crocante", "blando", "rugoso", "suave",
                        "áspero", "aterciopelado", "arrugado", "liso", "sedoso", "duro", "pegajoso", "adherente",
                        "común", "ordinario", "elegante", "tímido", "audaz", "extrovertido", "introvertido",
                        "entusiasta", "alegre", "feliz", "triste", "contento", "desanimado", "animado", "indiferente",
                        "sensible", "insensible", "rojo", "amarillo", "verde", "colorido", "contemporáneo", "moderno",
                        "antiguo", "rubio", "moreno", "decadente", "innovador", "joven", "viejo", "nuevo", "usado",
                        "analítico", "práctico", "firme", "blandengue", "sinuoso", "directo", "valiente", "cobarde",
                        "trabajador", "flojo", "disciplinado", "indisciplinado", "retador", "conformista", "simpático",
                        "antipático", "relajado", "tenso", "realista", "soñador", "cauteloso", "arriesgado", "sólido",
                        "líquido", "gaseoso", "húmedo", "seco", "brillante", "opaco", "luminoso", "oscuro", "claro",
                        "tenebroso", "amigable", "esperanzador", "tierno", "útil", "inútil", "dócil", "ágil", "vigente",
                        "actual", "obsoleto", "vencido", "luchador", "perdedor", "prudente", "imprudente", "atrevido",
                        "sigiloso", "talentoso", "fértil", "estéril", "fecundo", "prolífico", "dinámico", "estudioso",
                        "consecuente", "ambivalente", "solidario", "caritativo", "egoísta", "egocéntrico", "justo",
                        "sabio", "paciente", "riguroso", "poderoso", "débil", "frágil", "fuerte", "robusto",
                        "escurridizo", "baboso", "azulado", "castaño", "nublado", "vaporoso", "peludo", "lampiño",
                        "considerado", "desconsiderado", "espeluznante", "miedoso", "atemorizante", "amenazador",
                        "inspirador", "tentador", "insípido", "sorprendente", "caro", "barato", "irrompible",
                        "indestructible", "adorable", "travieso", "tranquilo", "colérico"
                    }
                }
            }
        );
    }
}