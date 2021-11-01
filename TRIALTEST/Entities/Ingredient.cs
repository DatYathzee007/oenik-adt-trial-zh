using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TRIALTEST.Entities
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Amount { get; set; }

        public int ReceiptId { get; set; }
        [NotMapped]
        public virtual Recipe Recipe { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id} - Name: {this.Name} - Amount: {this.Amount}";
        }

    }
}
