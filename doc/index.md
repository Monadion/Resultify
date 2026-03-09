---
_layout: landing
---

# Resultify

Resultify is a lightweight, fluent, functional-style Result library for C#.  
It provides `Result` and `Result<T>` with `Try`, `Map`, `Bind`, and `Match` to build safe, exception-free, chainable pipelines.

## Features

- **Fluent API** with `Try`, `Map`, `Bind`, `Match`  
- **`Result`** and **`Result<T>`** types  
- **Exception-safe** operations with `Result.Try`  
- Composable functional pipelines
- Lightweight and dependency-free

## Install

Install via NuGet:

```bash
dotnet add package Monadion.Resultify
```

## Quick Example
```c#
var message =
    Result.Try(() => int.Parse(input))
          .Map(x => x * 2)
          .Match(
              onSuccess: v => $"OK: {v}",
              onFailure: e => $"ERR: {e}"
          );
```

## Project Links

- [GitHub Repository](https://github.com/Monadion/Resultify)
- [Nuget Package]()
- [CHANGELOG](https://github.com/Monadion/Resultify/blob/main/CHANGELOG.md)