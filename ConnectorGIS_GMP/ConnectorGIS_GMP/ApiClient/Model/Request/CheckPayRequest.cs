using ConnectorGIS_GMP.ApiClient.Enum;

namespace ConnectorGIS_GMP.ApiClient.Model.Request
{
    /// <summary>
    /// Модель передаваемая в метод CheckPay.
    /// Больше инфы в API - https://shtraf.biz/API_shtraf.biz_Manual.pdf
    /// </summary>
    public class CheckPayRequest
    {
        /// <summary>
        /// Тип операции 1 = поиск начислений.
        /// </summary>
        public int Top { get; set; } = 1;

        /// <summary>
        /// Идентификатор Партнера.
        /// </summary>
        public string Id { get; set; } = "109731.1.03";

        /// <summary>
        /// Подпись запроса.
        /// </summary>
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// Тип поиска. 10 - штрафы, 21 - налоги, 24 - фссп
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Номер водительского удостоверения.
        /// Необязательное поле если в запросе есть sts.
        /// Поле передается только при type==10.
        /// </summary>
        public string? Vu { get; set; }

        /// <summary>
        /// Номер Свидетельства о регистрации транспортного средства.
        /// Необязательное поле, если в запросе присутствует поле vu.
        /// Обязательное поле, если в запросе присутствует поле num.
        /// </summary>
        public string? Sts { get; set; }

        /// <summary>
        /// Реквииты организации ИП для поиска штрафов ГИБДД.(Смотреть АПИ).
        /// </summary>
        public string? Org { get; set; }

        /// <summary>
        /// Номер Постановления об административном правонарушении.
        /// Передается вместо полей vu, sts, num, pasp.
        /// </summary>
        public string? Num { get; set; }

        /// <summary>
        /// Необязательное поле, если в запросе присутствует поле snilsn.
        /// Поле передается только при type==21 или type==24.
        /// Можно передать сразу несколько через ; (до 10).
        /// </summary>
        public string? Inn { get; set; }

        /// <summary>
        /// Необязательное поле,если в запросе присутствует поле inn.
        /// Поле передается толькопри type==21 или type==24.
        /// </summary>
        public string? Snils { get; set; }

        /// <summary>
        ///  Серия и номер паспорта
        ///  Необязательное поле,если в запросе присутствует поле inn или snils или vu или sts.
        ///  Поле передается только при type==10 и type==24 .
        /// </summary>
        public string? Pasp { get; set; }

        /// <summary>
        /// УИН при type==21 или type==24.
        /// Передается вместо полей inn, snils, pasp.
        /// </summary>
        public string? Ind { get; set; }

        /// <summary>
        /// 0 - искать только неоплаченные  начисления.
        /// 1 - искать оплаченные и неоплаченные начисления.
        /// </summary>
        public int Paid { get; set; } = 0;

        /// <summary>
        /// Номер постановление 
        /// </summary>
        public string? Ps { get; set; }
    }
}
