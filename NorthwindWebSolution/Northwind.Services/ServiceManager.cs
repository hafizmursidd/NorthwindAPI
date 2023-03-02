using Northwind.Domain.Base;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductPhotoServices> _lazyProductPhotoServices;
        private readonly Lazy<ISupplierServices> _lazySupplierServices;
        private readonly Lazy<IUtilityService> _lazyUtilityService;
        public ServiceManager(IRepositoryManager repositoryManager, IUtilityService utilityService)
        {
            _lazyProductPhotoServices = new Lazy<IProductPhotoServices> (() =>
            new ProductPhotoServices(repositoryManager, utilityService));

            _lazySupplierServices = new Lazy<ISupplierServices>(() =>
            new SupplierServices(repositoryManager));
        }

        public IProductPhotoServices ProductPhotoService => _lazyProductPhotoServices.Value;

        public ISupplierServices SupplierServices => _lazySupplierServices.Value;

    }
}
