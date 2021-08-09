using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Db;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShopWebApp
{
    public class ProductsCache : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMemoryCache cache;

        public ProductsCache(IServiceProvider serviceProvider, IMemoryCache cache)
        {
            this.serviceProvider = serviceProvider;
            this.cache = cache;
        }
        //Вызывается при старте приложения
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //запускается пока не закрыть приложение
            while (!stoppingToken.IsCancellationRequested)
            {
                //Кэширование продуктов
                CachingAllProducts();
                //создается задержка на 1 мин
                await Task.Delay(TimeSpan.FromMilliseconds(60000), stoppingToken);
            }
        }
        private void CachingAllProducts()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                // подключение к базе данных databaseContext с помощью scope(для каждого запроса создается свой объект)
                var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                //получение всех продуктов из базы данных
                var products = databaseContext.Products.Include(x => x.Images).ToList();
                //кэширование всего списка целиком по ключу Constants.KeyCacheAllProduct = "GetAllProduct";
                if (products != null)
                {
                    cache.Set(Constants.KeyCacheAllProducts, products);
                }
                //добавление(обновление) в кэш каждого продукта по отдельности по ключу product.Id
                foreach (var product in products)
                {
                    if (product != null)
                    {
                        cache.Set(product.Id, product);
                    }
                }
            }
        }
    }
}