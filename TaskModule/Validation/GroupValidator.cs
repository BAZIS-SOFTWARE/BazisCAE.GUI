using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskModule.Validation
{
    public class GroupValidator : ValidationAttribute
    {
        public List<string> Groups { get; set; }

        public GroupValidator(List<string> groups) 
        {
            Groups = groups;
        }

        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                if (Groups.Contains(str))
                    return true;
            }
            ErrorMessage = "Выбранная группа была изменена, или она не существует";
            return false;
        }
    }
}
