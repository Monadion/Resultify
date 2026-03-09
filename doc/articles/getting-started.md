# Getting Started

This guide shows how to quickly install and use the **Resultify** NuGet package in your .NET project.

## 1. Install via NuGet

You can install the package using the **.NET CLI**:

```bash
dotnet add package Monadion.Resultify
```

Or via Visual Studio:

1. Right-click on your project → Manage NuGet Packages…

2. Search for Monadion.Resultify

3. Click Install

## 2. Add a Using Statement

In your C# code, add:

```c#
using Monadion.Resultify;
```

## 3. Example Usage

Here’s a simple example of how to use the package:

```c#
using Monadion.Resultify;

Result result = Result.Success();

if (result.IsSuccess)
{
    Console.WriteLine("result success");
}
```