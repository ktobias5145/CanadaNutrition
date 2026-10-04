namespace CanadaNutrition
{

    internal partial class Program
    {
        public class NutrientName
        {
            public int NutrientID { get;set; }
            public int NutrientCode { get; set; }
            public string? NutrientSymbol { get; set; }
            public string? NutrientUnit { get; set; }
            public string? NutrientNameE { get; set; }
            public string? NutrientNameF { get; set; }
            public string? Tagname { get; set; }
            public int NutrientDecimals { get; set; }
            public NutrientName() { }
            public NutrientName(int nutrientID, int nutrientCode, string? nutrientSymbol, string? nutrientUnit, string? nutrientNameE, string? nutrientNameF, string? tagname, int nutrientDecimals)
            {
                NutrientID = nutrientID;
                NutrientCode = nutrientCode;
                NutrientSymbol = nutrientSymbol;
                NutrientUnit = nutrientUnit;
                NutrientNameE = nutrientNameE;
                NutrientNameF = nutrientNameF;
                Tagname = tagname;
                NutrientDecimals = nutrientDecimals;
            }
        }
    }
}
