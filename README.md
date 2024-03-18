# OGA.DomainBase
Base Library for Domain Entities and value objects

## Description
This is the base set of standardized classes for domain design usage.
The intention of this library is to be consumed by the domain layer of an application.
Specifically, this library is meant to provide the base domain entity and value object in a layered domain driven design.

This library includes the following:
* Aggregate root interface, to be inherited by all aggregate types.
* Base repository interface, to be inherited by all repository classes.
* Base configuration element entity class for standardized configuration storage.
* Base domain object, to be inherited by all domain classes.
* Base value object, to be inherited by all value objects, and classes with sample usage.
* Base user context class, to allow for the implementation of role-based security at the domain service layer.
* Query helpers to produce sorted and filtered paginated query results, at the domain service layer, with predicate building.
* Domain Service base, which includes UserContext and corelationId tracking.

## Features
One feature of the domain base in this library is that the Id property is generic. It can be long, Int32, Guid, string, etc...\
This provides flexibility for different design cases:
* Small domains or ones that that need the lookup speed of integer-based keys.
* Domain that use keys with embedded type... key strings such as 'vm:1234' (like the MoRef in the VSphere domain model).
* Large decentralized models, where the design choice for key type is driven by collisionless eventual consistency (Guid keys exist at instantiation).
* A write-model paradigm, recording immutable events for posterity, whose left-fold (projection) of events must recreate entities with the same key, everytime.

## Installation
OGA.DomainBase is available via NuGet:
* NuGet Official Releases: [![NuGet](https://img.shields.io/nuget/vpre/OGA.DomainBase.svg?label=NuGet)](https://www.nuget.org/packages/OGA.DomainBase)

## Dependencies
This library depends on:
* [OGA.SharedKernel](https://github.com/LeeWhite187/OGA.SharedKernel)
* [NLog](https://github.com/NLog/NLog/)

## Building OGA.DomainBase
This library is built with the new SDK-style projects.
It contains multiple projects, one for each of the following frameworks:
* NET 5
* NET 6
* NET 7

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

## Opinionation Apology...
This library references NLog, directly, for now.\
I understand this may appear overly opinionated, at the domain layer. I agree... though, NLog works very well.\
Once I get a chance to circle back, and work through a more agnostic logging interface, I will update (removing the specific logger tie).

You're welcome to swap out and compile whatever logger you'd like, of course.\
If you have the need or feel inclined, send me feedback or a pull, so I know it helps someone, to make time and generalize the logger.
