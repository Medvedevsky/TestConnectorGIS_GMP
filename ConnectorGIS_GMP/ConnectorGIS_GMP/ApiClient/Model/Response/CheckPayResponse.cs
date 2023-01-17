namespace ConnectorGIS_GMP.ApiClient.Model.Response
{
    public class CheckPayResponse
    {
        /// <summary>
        /// Список начислений где key - уникальный номер начисления в котором содержиться уин
        /// </summary>
        public Dictionary<string, Calculation>? L { get; set; }
    }
}