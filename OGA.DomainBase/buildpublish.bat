REM NET Core Software Library

REM Build the library...
dotnet restore "./OGA.DomainBase_NET5/OGA.DomainBase_NET5.csproj"
dotnet build "./OGA.DomainBase_NET5/OGA.DomainBase_NET5.csproj" -c DebugLinux --runtime linuxs --no-self-contained

dotnet restore "./OGA.DomainBase_NET5/OGA.DomainBase_NET5.csproj"
dotnet build "./OGA.DomainBase_NET5/OGA.DomainBase_NET5.csproj" -c DebugWin --runtime win --no-self-contained

dotnet restore "./OGA.DomainBase_NET6/OGA.DomainBase_NET6.csproj"
dotnet build "./OGA.DomainBase_NET6/OGA.DomainBase_NET6.csproj" -c DebugLinux --runtime linux --no-self-contained

dotnet restore "./OGA.DomainBase_NET6/OGA.DomainBase_NET6.csproj"
dotnet build "./OGA.DomainBase_NET6/OGA.DomainBase_NET6.csproj" -c DebugWin --runtime win --no-self-contained

dotnet restore "./OGA.DomainBase_NET7/OGA.DomainBase_NET7.csproj"
dotnet build "./OGA.DomainBase_NET7/OGA.DomainBase_NET7.csproj" -c DebugLinux --runtime linux --no-self-contained

dotnet restore "./OGA.DomainBase_NET7/OGA.DomainBase_NET7.csproj"
dotnet build "./OGA.DomainBase_NET7/OGA.DomainBase_NET7.csproj" -c DebugWin --runtime win --no-self-contained

REM Create the composite nuget package file from built libraries...
C:\Programs\nuget\nuget.exe pack ./OGA.DomainBase.nuspec -IncludeReferencedProjects -symbols -SymbolPackageFormat snupkg -OutputDirectory ./Publish -Verbosity detailed

REM To publish nuget package...
dotnet nuget push -s http://192.168.1.161:8080/v3/index.json ".\Publish\OGA.DomainBase.2.0.6.nupkg"
dotnet nuget push -s http://192.168.1.161:8080/v3/index.json ".\Publish\OGA.DomainBase.2.0.6.snupkg"
