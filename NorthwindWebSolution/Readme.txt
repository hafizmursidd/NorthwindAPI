
One To Many Post.
Tahapannya ialah
- create supplier entity
- Create DTO (Supplier dto dan Supplier product list dto)
- create supplier Repository
		create iSupplierRepo,
		create SupplierRepo lalu inherit ke IsupplierRepo
- Register to Repository manager
		register ISupplierRepo to RepositoryManager
		implements to repositorymanager
- create supplier service
		create Isupplierservice to projrct Service.Abstract
		implement supplierservice to projrct service
- register to Servicemanager
- create Suppliercontroller