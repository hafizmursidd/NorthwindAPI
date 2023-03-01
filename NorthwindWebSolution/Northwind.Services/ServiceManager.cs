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
        private readonly Lazy<IUtilityService> _lazyUtilityService;
        public ServiceManager(IRepositoryManager repositoryManager, IUtilityService utilityService)
        {
            _lazyProductPhotoServices = new Lazy<IProductPhotoServices> (() =>
            new ProductPhotoServices(repositoryManager, utilityService));
        }
        public IProductPhotoServices ProductPhotoServices => _lazyProductPhotoServices.Value;
    }
}
