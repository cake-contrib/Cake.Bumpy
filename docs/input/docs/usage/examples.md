# Usage

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
