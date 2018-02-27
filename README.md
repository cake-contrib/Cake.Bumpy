# Cake.Bumpy

Cake.Bumpy is an Addin for [Cake](http://cakebuild.net/) which can help you to manage version information across several files in your project using the command line tool [Bumpy](https://github.com/fwinkelbauer/Bumpy).

## Usage

In order to use the commands for this addin, you will need to include the following in your build.cake file to download and reference from NuGet.org:

```csharp
#tool Bumpy
```

In addition, you will need to include the following:

```csharp
#addin Cake.Bumpy
```

Afterwards you can start to use the Addin, e.g.:

```csharp
BumpyIncrement(2);
```

You can learn more about using Bumpy and the Addin from the respective documentation [here](https://github.com/fwinkelbauer/Bumpy) and [here](https://cakebuild.net/dsl/bumpy/).

## Example

The `Example` folder in this repository outlines a simple build script which can be used to increment versions in some files using a `.bumypconfig` file:

```csharp
#tool Bumpy
#addin Cake.Bumpy

var target = Argument("target", "Default");

Task("Default")
    .Does(() =>
{
    Information("Bumpy increment:");
    BumpyIncrement(3);
});

RunTarget(target);
```

To see the example in action run:

```powershell
cd .\Example
.\build.ps1
```

Sample output:

```
========================================
Default
========================================
Executing task: Default
Bumpy increment:
\my_version_file1.txt (0): 1.0.0 -> 1.0.1
\my_version_file2.txt (0): 1.0.0 -> 1.0.1
Finished executing task: Default
```

## License

[MIT](http://opensource.org/licenses/MIT)
