# Resultify

**Resultify** is a lightweight, fluent, and functional-style Result library for C#.  
It provides `Result` and `Result<T>` types with **Try, Map, Bind, and Match** operations, 
enabling safe error handling, fluent pipelines, and exception-free code.

[![NuGet](https://img.shields.io/nuget/v/Monadion.Resultify.svg)](https://www.nuget.org/packages/Monadion.Resultify)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![GitHub](https://img.shields.io/badge/github-Monadion%2FResultify-black)](https://github.com/Monadion/Resultify)
[![Build](https://img.shields.io/github/actions/workflow/status/Monadion/Resultify/ci.yml?branch=main)](https://github.com/Monadion/Resultify/actions)

---

## Why Resultify?

Exceptions can make control flow unpredictable and expensive.  
Resultify provides a functional approach to error handling with explicit success and failure states.

## Features

- **Fluent API** with `Try`, `Map`, `Bind`, `Match`  
- **Non-generic** and **generic** `Result` types  
- **Exception-safe** operations with `Result.Try`  
- Fully **chainable pipelines** for functional programming style  

---

## Installation

You can install the package via NuGet:

```bash
dotnet add package Monadion.Resultify
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

See the full [documentation](https://monadion.github.io/Resultify/).

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) before submitting pull requests.

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for release history.

## License

MIT License — see [LICENSE](LICENSE).

## Code of Conduct

See [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md).

## Security

See [SECURITY.md](SECURITY.md).