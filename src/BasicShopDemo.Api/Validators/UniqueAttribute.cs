using BasicShopDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using Pluralize.NET.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BasicShopDemo.Api.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        public bool AcceptNull;

        public UniqueAttribute(bool acceptNull = false)
        {
            AcceptNull = acceptNull;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (BasicShopContext)validationContext.GetService(typeof(BasicShopContext));
            var model = (Entity)validationContext.ObjectInstance;
            var className = validationContext.ObjectType.Name.Split('.').Last();
            var field = validationContext.MemberName;
            var tableName = new Pluralizer().Pluralize(className);

            if (!AcceptNull && value != null)
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    var extraCondition = string.Empty;

                    if (model.Id > 0)
                    {
                        extraCondition += $"AND ID <> {model.Id}";
                    }

                    command.CommandText = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = '{2}' {3}", tableName, field, value, extraCondition);
                    context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                if (result.GetInt32(0) > 0)
                                {
                                    return new ValidationResult(string.Format("There is already a {0} with the {1} '{2}'", className, field, value.ToString()),
                                    new List<string>() { field });
                                }
                            }
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}