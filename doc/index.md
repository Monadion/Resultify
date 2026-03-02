---
_layout: landing
---

# Resultify

Resultify is a lightweight, fluent, functional-style Result library for C#.  
It provides `Result` and `Result<T>` with `Try`, `Map`, `Bind`, and `Match` to build safe, exception-free, chainable pipelines.

## Install

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

## Features

- **Fluent API** with `Try`, `Map`, `Bind`, `Match`  
- **Non-generic** and **generic** `Result` types  
- **Exception-safe** operations with `Result.Try`  
- Designed for chainable functional pipelines 


## Next steps

- Getting Started: `articles/getting-started.md`
- Examples: `articles/examples.md`
- Changelog: `../CHANGELOG.md`