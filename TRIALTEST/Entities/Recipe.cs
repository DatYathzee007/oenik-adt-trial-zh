using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TRIALTEST.Entities
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsRomantic { get; set; }
        [NotMapped]
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id} - Name: {this.Name} - Price: {this.Price} - IsRomantic: {this.IsRomantic}";
        }
    }
}
