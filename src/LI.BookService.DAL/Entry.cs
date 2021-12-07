using Microsoft.Extensions.DependencyInjection;

namespace LI.BookService.DAL
{
    public static class Entry
    {
        public static IServiceCollection AddDLLServices(this IServiceCollection serviceCollection)
        {
           // тут зарегестрируете зависимости

            return serviceCollection;
        }
    }
}
