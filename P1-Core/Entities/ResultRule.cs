using System.ComponentModel.DataAnnotations.Schema;

namespace P1_Core.Entities {

    public class ResultRule :BaseEntity {
        
        [ForeignKey("ResultsId")]
        public int ResultsId { get; set; }
        [ForeignKey("RulesId")]
        public int RulesId { get; set; }
        
        [NotMapped]
        public new int Id {get;set;}
    }
}