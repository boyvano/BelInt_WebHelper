using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BelInt_WebHelper.Models.DataModels
{
    public class Contract
    {
        //Порядковый номер строки.
        public int RowNomer { get; set; }

        // Дата регистрации договора на предприятии.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        //Номер договора
        public string ContractId { get; set; }

        //Наименование предприятия
        public string CompanyName { get; set; }

        //Номер валютного договора
        public string CurrencyContractId { get; set; }

        // Дата регистрации договора в нац.банке
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegDateCurrContract { get; set; }

        //Сумма договора
        public double SummaryPayment { get; set; }
        // Валюта договора. Та, в которой клиенту согласована стоимость оказываемой услуги        
        public string ContractCurrency { get; set; }

        // Валюта платежа. Та, в которой клиентосуществляет оплату        
        public string ContractPayment { get; set; }
        // Страна регистрации       
        public string CountryOfRegister { get; set; }
        // Срок договора. Или дата, или бессрочный
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfContract { get; set; }

        // Исполнитель. Пользователь, ответственный за исполнение данного договора
        public string UserId { get; set; }

        // Порядок оплаты. Предоплата (100%) или отсрочка - выбор шаблона договора
        public string PaymentType { get; set; }

        // Вознаграждения. Ставка или процент - выбор шаблона договора
        public string Reward { get; set; }

        // работа в текущем году. Оказывались ли услуги в текущем году или нет.
        public bool IsYearWork { get; set; }
    }
}
