# Resultify

[![NuGet](https://img.shields.io/nuget/v/Monadion.Resultify.svg)](https://www.nuget.org/packages/Monadion.Resultify)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

**Resultify** is a lightweight, fluent, and functional-style Result library for C#.  
It provides `Result` and `Result<T>` types with **Try, Map, Bind, and Match** operations, 
enabling safe error handling, fluent pipelines, and exception-free code.

---

## Features

- **Fluent API** with `Try`, `Map`, `Bind`, `Match`  
- **Non-generic** and **generic** `Result` types  
- **Exception-safe** operations with `Result.Try`  
- Supports **NuGet packaging** with metadata, icon, and tags  
- Fully **chainable pipelines** for functional programming style  

---

## Installation

You can install the package via NuGet:

```bash
dotnet add package Resultify
```

## Quick Example

```c#
var message =
    Result.Try(() => int.Parse(input))
          .Map(x => x * 2)
          .Match(
              onSuccess: value => $"OK: {value}",
              onFailure: error => $"ERR: {error}"
          );
```

## Documentation

Full documentation and guides reference:

https://Monadion.github.io/Resultify/

Getting Started

Functional Pipelines

API Reference

Advanced Usage

## Changelog

See [CHANGELOG.md]() for release history.

## License

MIT License — see [LICENSE]()