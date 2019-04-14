# Intrusction for use:

NuGet: MongoDB.Driver

Add **CopyLocalLockFileAssemblies** to **PropertyGroup** of the **.csproj** file with **true** value, this will copy Mongo drivers to local on build.


# Features:

All DB operations are generic and require the POCO being passed on call.

All DB operations are Async, for Get methods, .Result at the end of the calling statement will retrieve the results immediately, as can be seen in main.cs

Insert, Update & Delete are fire and forget in this version, but can easily be extended with async task which can be monitored from calling class for success.

1) Insert
2) Update
3) Delete
4) Get Single
5) Get List
