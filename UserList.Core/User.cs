using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserList.Core
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Surname { get; set; }
        [Required, StringLength(80)]
        public string Email { get; set; }
        [Required, StringLength(80)]
        public string Country { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirthday { get; set; }
        public Gender Gender { get; set; }


    }
}
