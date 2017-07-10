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
