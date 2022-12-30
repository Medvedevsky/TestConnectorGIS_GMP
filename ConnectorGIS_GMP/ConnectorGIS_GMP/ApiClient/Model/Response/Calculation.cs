namespace ConnectorGIS_GMP.ApiClient.Model.Response
{
    public class Calculation
    {
        /// <summary>
        /// Сумма начислений к оплате.
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Первоначальная сумма начисления.
        /// </summary>
        public decimal SumPay { get; set; }

        /// <summary>
        /// Признак оплаты начисления true (или 1,2,3) - оплачен, false (или 0) - неоплачен.
        /// </summary>
        public int IsPaid { get; set; }

        /// <summary>
        /// Дополнительная информация о начислении.
        /// </summary>
        public string? Addinfo { get; set; }

        /// <summary>
        /// Дата внесения начисления в систему ГИС ГМП.
        /// </summary>
        public string Dat { get; set; }

        /// <summary>
        /// Тип начисления type==10 — штраф, type==23 - налог, type==24 — ИП ФССП.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// ID Документа по которому найдено начисление (Номера ВУ, СТС, ИНН, СНИЛС или других документов). 
        /// </summary>
        public string PayerIdentifier { get; set; }

        /// <summary>
        /// Ссылка на статью КОАП по правонарушению из системы ГИС ГМП (для начислений type==10).
        /// </summary>
        public string? ArticleCode { get; set; }

        /// <summary>
        /// Место совершения правонарушения (для начислений type==10).
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Размер действующей скидки в % на оплату штрафа (для начислений type==10).
        /// </summary>
        public decimal? DiscountSize { get; set; }

        /// <summary>
        /// Дата, при оплате до которой действует скидка на оплату штрафа (для начислений type==10).
        /// </summary>
        public string? DiscountDate { get; set; }

        /// <summary>
        /// Общая сумма штрафа (без учета скидки). Может совпадать с полем sum, если скидки нет(например штраф просрочен).
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Url на страницу загрузки фото с места правонарушения. Только при поиске штрафов ГИБДД.
        /// </summary>
        public string? UrlPhoto { get; set; }

        /// <summary>
        /// Замаскированный номер автомобиля, вида О590******
        /// </summary>
        public string? CarNumber { get; set; }

        /// <summary>
        /// Имя владельца автомобиля.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Код подразделения ГИБДД, оформившего Постановление.
        /// </summary>
        public string? Odps { get; set; }

        /// <summary>
        /// Наименование подразделения ГИБДД.
        /// </summary>
        public string? OdpsName { get; set; }

        /// <summary>
        /// Адрес подразделения ГИБДД.
        /// </summary>
        public string? OdpsAddr { get; set; }

        /// <summary>
        /// Модель автотранспортного средства.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// УИН - уникальный идентификатор начисления.
        /// </summary>
        public string Uin { get; set; }

        /// <summary>
        /// «Крайняя» дата оплаты Постановления в формате ДД.ММ.ГГГГ после которой оплата считается просроченной.
        /// </summary>
        public string? UntilDate { get; set; }

        /// <summary>
        /// Банковские реквизиты Получателя платежа.
        /// </summary>
        public Bank Bank { get; set; }
    }
}
