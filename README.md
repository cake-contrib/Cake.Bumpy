# Cake.Bumpy

Cake.Bumpy is an Addin for [Cake](http://cakebuild.net/) which can help you to manage version information across several files in your project using the command line tool [Bumpy](https://github.com/fwinkelbauer/Bumpy).

## Usage

In order to use the commands for this addin, you will need to include the following in your build.cake file to download and reference from NuGet.org:

```csharp
#tool Bumpy
```

In addition, you will need to include the following:

```csharp
#addin "Cake.Bumpy"
```

Afterwards you can start to use the Addin using its aliases, e.g.:

```csharp
BumpyIncrement(2);
```

## License

[MIT](http://opensource.org/licenses/MIT)
