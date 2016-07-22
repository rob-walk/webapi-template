# Web Api Template #

Web Api boiler plate for new projects.

## Projects in solution ##

* WebApi - web api, mvc included
* WebApi.Common - shared code, interfaces, etc.
* Database - SSDT project
* Unit tests
 * WebApi.Tests
 * WebApi.Common.Tests
 
## Dependancies ##
 
 * Web Api 2, MVC 5
 * Autofac
 * AutoMapper
 * log4net
 * Entity Framework
 * nunit
 
## Other Information ##

* DI setup for controllers and domain
* Complete data access layer, configured for sql server.
 1. Configure connection string
 2. Add database table
 2. create a poco and inherit from Entity
 3. Expose poco in IAnyDbContext
 4. Add IDataService as constructor parameter to a controller
 5. Read and write the data.
* Auto error logging
* Confuration transforms for dev, test, prod.
* Attribute routing
* Shared assembly versioning
* Nuget dependancy managment
