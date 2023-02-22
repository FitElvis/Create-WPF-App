md %1
cd %1
md Code
md Docs
cd Code
dotnet new Create-WPF-Application --name %1 -lang C#
