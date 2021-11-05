using System.ComponentModel.DataAnnotations;
namespace api_empresa.Models{
    public class Medicine{
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public string category {get;set;}
        public string price {get;set;}
        public string box {get;set;}
        public string s_price {get;set;}
        public int quantity {get;set;}
        public string generic {get;set;}
        public string company {get;set;}
        public string effects {get;set;}
        public string e_date {get;set;}
        public string add_date {get;set;}
        public string hospital_id {get;set;}

    }
}