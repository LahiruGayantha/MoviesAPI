using MoviesAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entities
{
    public class Genre
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="The field with name {0} is required")]
        [StringLength(10)]
        public string Name { get; set; }
        public List<MovieGenres> MovieGenres { get; set; }

        ////This is module validation function
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(Name))
        //    {
        //        var firstLetter = Name[0].ToString();
        //        if(firstLetter != firstLetter.ToUpper())
        //        {
        //            yield return new ValidationResult("First letter should be an uppercase letter",new String[] { nameof(Name) });
        //        }
        //    }
        //}
    }
}
