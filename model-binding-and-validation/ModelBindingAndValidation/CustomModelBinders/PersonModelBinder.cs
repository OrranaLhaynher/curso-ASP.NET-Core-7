using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindingAndValidation.Models;

namespace ModelBindingAndValidation.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.Name = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.Name += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
            {
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Length > 0)
            {
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("DateOfBirth").Length > 0)
            {
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue;
            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
