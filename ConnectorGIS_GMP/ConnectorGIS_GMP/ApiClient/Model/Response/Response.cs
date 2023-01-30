namespace ConnectorGIS_GMP.ApiClient.Model.Response
{
    public class Response
    {
        public ResponseError Error { get; set; } = new();
        public CheckPayResponse? Data { get; set; } 
    }
}
