namespace ConnectorGIS_GMP.ApiClient.Model.Response
{
    public class ResponseError
    {
        /// <summary>
        /// Тип родительской операции.
        /// </summary>
        public int Top { get; set; }
        /// <summary>
        /// Код ошибки. Список кодов смотреть в апи
        /// </summary>
        public int Err { get; set; }
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string? Msg { get; set; }
    }
}
