using Restful.Shared.IRepositories;
using Restful.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Services.Services.Seeds
{
    public class SeedService : ISeedService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IContentRepository _contentRepository;


        public SeedService(IOrderRepository orderRepository, IPackageRepository packageRepository, IContentRepository contentRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _packageRepository = packageRepository ?? throw new ArgumentNullException(nameof(packageRepository));
            _contentRepository = contentRepository ?? throw new ArgumentNullException(nameof(contentRepository));
        }
        public async Task SeedDatabase()
        {
            var order1 = new Order() { OrderId = Guid.NewGuid(), OrderNo = 1, Packages = new List<Package>() };
            var order2 = new Order() { OrderId = Guid.NewGuid(), OrderNo = 2, Packages = new List<Package>() };
            var order3 = new Order() { OrderId = Guid.NewGuid(), OrderNo = 3, Packages = new List<Package>() };
            var order4 = new Order() { OrderId = Guid.NewGuid(), OrderNo = 4, Packages = new List<Package>() };
            var order5 = new Order() { OrderId = Guid.NewGuid(), OrderNo = 5, Packages = new List<Package>() };
            var order6 = new Order() { OrderId = Guid.NewGuid(), OrderNo = 6, Packages = new List<Package>() };
            var order7 = new Order() { OrderId = Guid.NewGuid(), OrderNo = 7, Packages = new List<Package>() };

            var package11 = new Package() { OrderId = order1.OrderId, PackageId = Guid.NewGuid(), Contents = new List<Content>() };
            var package12 = new Package() { OrderId = order1.OrderId, PackageId = Guid.NewGuid(), Contents = new List<Content>() };
            var package13 = new Package() { OrderId = order1.OrderId, PackageId = Guid.NewGuid(), Contents = new List<Content>() };
            var package14 = new Package() { OrderId = order1.OrderId, PackageId = Guid.NewGuid(), Contents = new List<Content>() };
            var package15 = new Package() { OrderId = order1.OrderId, PackageId = Guid.NewGuid(), Contents = new List<Content>() };
            var package16 = new Package() { OrderId = order1.OrderId, PackageId = Guid.NewGuid(), Contents = new List<Content>() };
            var package17 = new Package() { OrderId = order1.OrderId, PackageId = Guid.NewGuid(), Contents = new List<Content>() };

            var listOfContentsForPackage11 = new List<Content>()
            {
                new Content() { ContentId = Guid.NewGuid(), PackageId = package11.PackageId, Color = "Red", Description = "Shirt", QuantityOrdered = 10, Size = "XS" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package11.PackageId, Color = "Red", Description = "Shirt", QuantityOrdered = 10, Size = "S" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package11.PackageId, Color = "Red", Description = "Shirt", QuantityOrdered = 10, Size = "M" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package11.PackageId, Color = "Red", Description = "Shirt", QuantityOrdered = 10, Size = "L" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package11.PackageId, Color = "Red", Description = "Shirt", QuantityOrdered = 10, Size = "XL" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package11.PackageId, Color = "Red", Description = "Shirt", QuantityOrdered = 10, Size = "XXL" }

            };

            var listOfContentsForPackage12 = new List<Content>()
            {
                new Content() { ContentId = Guid.NewGuid(), PackageId = package12.PackageId, Color = "Black", Description = "Pants", QuantityOrdered = 10, Size = "XS" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package12.PackageId, Color = "Black", Description = "Pants", QuantityOrdered = 10, Size = "S" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package12.PackageId, Color = "Black", Description = "Pants", QuantityOrdered = 10, Size = "M" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package12.PackageId, Color = "Black", Description = "Pants", QuantityOrdered = 10, Size = "L" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package12.PackageId, Color = "Black", Description = "Pants", QuantityOrdered = 10, Size = "XL" },
                new Content() { ContentId = Guid.NewGuid(), PackageId = package12.PackageId, Color = "Black", Description = "Pants", QuantityOrdered = 10, Size = "XXL" }

            };

            await _orderRepository.AddAsync(order1);
            await _packageRepository.AddAsync(package11);
            await _packageRepository.AddAsync(package12);
            await _contentRepository.AddRangeAsync(listOfContentsForPackage11);
            await _contentRepository.AddRangeAsync(listOfContentsForPackage12);


        }
    }
}
