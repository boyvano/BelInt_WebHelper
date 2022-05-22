using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BelInt_WebHelper.Models.DataModels
{
    public class Contract
    {
        [Display(Name ="")]
        public bool IsChecked { get; set; }

        // Порядковый номер строки.
        [Display(Name = "Порядковый номер строки")]
        public int RowNumber { get; set; }

        // Дата регистрации договора на предприятии.
        [Display(Name = "Дата регистрации договора")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

        // Номер договора
        [Display(Name = "Номер договора")]
        public string ContractId { get; set; }

        // Наименование предприятия(клиента)
        [Display(Name = "Предприятие")]
        public string CompanyName { get; set; }

        // Номер валютного договора
        [Display(Name = "Номер валютного договора")]
        public string CurrencyContractId { get; set; }

        // Дата регистрации договора в нац.банке
        [Display(Name = "Дата регистрации договора в НБ")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string RegDateCurrContract { get; set; }

        // Сумма договора
        [Display(Name = "Сумма договора")]
        public string SummaryPayment { get; set; }

        // Валюта договора. Та, в которой клиенту согласована стоимость оказываемой услуги        
        [Display(Name = "Валюта договора")]
        public string ContractCurrency { get; set; }

        // Валюта платежа. Та, в которой клиентосуществляет оплату        
        [Display(Name = "Валюта платежа")]
        public string ContractPayment { get; set; }

        // Страна регистрации       
        [Display(Name = "Страна регистрации")]
        public string CountryOfRegister { get; set; }

        // Срок договора. Или дата, или бессрочный
        //[Display(Name = "Срок договора")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfContract { get; set; }

        // Исполнитель. Пользователь, ответственный за исполнение данного договора
        [Display(Name = "Исполнитель")]
        public string UserId { get; set; }

        // Порядок оплаты. Предоплата (100%) или отсрочка - выбор шаблона договора
        [Display(Name = "Порядок оплаты")]
        public string PaymentType { get; set; }

        // Вознаграждения. Ставка или процент - выбор шаблона договора
        [Display(Name = "Вознаграждения")]
        public string Reward { get; set; }

        // Работа в текущем году. Оказывались ли услуги в текущем году или нет.
        [Display(Name = "Работа в текущем году")]
        public bool IsYearWork { get; set; }
    }
}
