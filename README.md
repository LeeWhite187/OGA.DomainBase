# OGA.DomainBase
Base Library for Domain Entities and value objects

## Description
This is the base set of standardized classes for domain design usage.
It includes the following:
* Aggregate root interface, to be inherited by all aggregate types.
* Base repository interface, to be inherited by all repository classes.
* Base configuration element entity class for standardized configuration storage.
* Base domain object, to be inherited by all domain classes.
* Base value object, to be inherited by all value objects, and classes with sample usage.
* Base user context class, to allow for the implementation of role-based security at the domain service layer.
* Query helpers to produce sorted and filtered paginated query results, at the domain service layer, with predicate building.

## Installation
OGA.DomainBase is available via NuGet:
* NuGet Official Releases: [![NuGet](https://img.shields.io/nuget/vpre/OGA.DomainBase.svg?label=NuGet)](https://www.nuget.org/packages/OGA.DomainBase)

## Dependencies
This library depends on:
* [OGA.SharedKernel](https://github.com/LeeWhite187/OGA.SharedKernel)
* [NLog](https://github.com/NLog/NLog/)
* [Newtonsoft.JSON](https://github.com/JamesNK/Newtonsoft.Json)

## Building OGA.DomainBase
This library is built with the new SDK-style projects.
It contains multiple projects, one for each of the following frameworks:
* NET 5
* NET 6

And, the output nuget package includes runtimes targets for:
* linux-64
* win-x64

## Framework and Runtime Support
Currently, the nuget package of this library supports the framework versions and runtimes of applications that I maintain (see above).
If someone needs others (older or newer), let me know, and I'll add them to the build script.

## Visual Studio
It is currently built using Visual Studio 2019 17.1.

## License
Please see the [License](LICENSE).
