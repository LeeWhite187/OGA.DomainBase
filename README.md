# OGA.DomainBase
Base Library for Domain Entities

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

## Project Organizational Notes
This library supports multiple Net Core targets (5 and 6) from a single Shared Project.
And, it also include testing in both targets from a single Shared project (of testing code).
Here's a list of the projects, to clarify each one's purpose:
* OGA_DomainBase_NET5			Net 5 Target project
* OGA_DomainBase_NET6			Net 6 Target project
* OGA_DomainBase_SP			    Shared code for target projects
* OGA_DomainBase_NET5_Tests     Net 5 Target tests
* OGA_DomainBase_NET6_Tests     Net 6 Target tests
* OGA_DomainBase_Tests_SP		Shared code of test projects

## Installation
OGA.DomainBase is available via NuGet:
* NuGet Official Releases: [![NuGet](https://img.shields.io/nuget/vpre/OGA.DomainBase.svg?label=NuGet)](https://www.nuget.org/packages/OGA.DomainBase)

## Dependencies
This library depends on:
* [OGA.SharedKernel](https://github.com/LeeWhite187/OGA.SharedKernel)

## Building OGA.DomainBase
This library is built with the new SDK-style projects.
It contains multiple projects, one for each of the following frameworks:
* NET 5
* NET 6

And, the output nuget package includes runtimes targets for:
* linux-64
* win-x64

## Visual Studio
It is currently built using Visual Studio 2019 17.1.

## License
Please see the [License](LICENSE).
