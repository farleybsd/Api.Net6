using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErros(this ModelStateDictionary modelstate)
        {
            var result = new List<string>();

            foreach (var item in modelstate.Values)
            {
                foreach (var erro in item.Errors)
                {
                    result.Add(erro.ErrorMessage);
                }
            }

            return result;
        }
    }
}
