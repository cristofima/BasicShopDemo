using BasicShopDemo.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BasicShopDemo.Api.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (BasicShopContext)validationContext.GetService(typeof(BasicShopContext));

            var model = validationContext.ObjectInstance;
            var field = validationContext.MemberName;

            if (model is Product)
            {
                var product = (Product)model;
                if (product.Id == 0)
                {
                    if (field.Equals("Name"))
                    {
                        var duplicateProduct = context.Product.FirstOrDefault(c => c.Name == product.Name);
                        if (duplicateProduct != null)
                        {
                            return new ValidationResult($"There is already a Product with the name '{product.Name}'");
                        }
                    }
                    else if (field.Equals("Code"))
                    {
                        var duplicateProduct = context.Product.FirstOrDefault(c => c.Code == product.Code);
                        if (duplicateProduct != null)
                        {
                            return new ValidationResult($"There is already a Product with the code '{product.Code}'");
                        }
                    }
                }
                else
                {
                    if (field.Equals("Name"))
                    {
                        var duplicateProduct = context.Product.FirstOrDefault(c => c.Name == product.Name && c.Id != product.Id);
                        if (duplicateProduct != null)
                        {
                            return new ValidationResult($"There is already a Product with the name '{product.Name}'");
                        }
                    }
                    else if (field.Equals("Code"))
                    {
                        var duplicateProduct = context.Product.FirstOrDefault(c => c.Code == product.Code && c.Id != product.Id);
                        if (duplicateProduct != null)
                        {
                            return new ValidationResult($"There is already a Product with the code '{product.Code}'");
                        }
                    }
                }
            }
            else if (model is Category)
            {
                var category = (Category)model;
                if (category.Id == 0)
                {
                    if (field.Equals("Name"))
                    {
                        var duplicateCategory = context.Category.FirstOrDefault(c => c.Name == category.Name);
                        if (duplicateCategory != null)
                        {
                            return new ValidationResult($"There is already a Category with the name '{category.Name}'");
                        }
                    }
                    else if (field.Equals("Code"))
                    {
                        var duplicateCategory = context.Category.FirstOrDefault(c => c.Code == category.Code);
                        if (duplicateCategory != null)
                        {
                            return new ValidationResult($"There is already a Category with the code '{category.Code}'");
                        }
                    }
                }
                else
                {
                    if (field.Equals("Name"))
                    {
                        var duplicateCategory = context.Category.FirstOrDefault(c => c.Name == category.Name && c.Id != category.Id);
                        if (duplicateCategory != null)
                        {
                            return new ValidationResult($"There is already a Category with the name '{category.Name}'");
                        }
                    }
                    else if (field.Equals("Code"))
                    {
                        var duplicateCategory = context.Category.FirstOrDefault(c => c.Code == category.Code && c.Id != category.Id);
                        if (duplicateCategory != null)
                        {
                            return new ValidationResult($"There is already a Category with the code '{category.Code}'");
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}