# Versioning & Compatibility

Resultify follows **Semantic Versioning (SemVer)** to provide predictable and transparent version management.

Version format:

MAJOR.MINOR.PATCH

Example:
1.4.2

---

## Semantic Versioning Rules

### MAJOR (X.0.0)
Incremented when breaking changes are introduced.

Breaking changes may include:
- Public API signature changes
- Removed or renamed methods
- Constructor parameter changes
- Behavioral changes that alter expected outcomes
- Namespace changes

### MINOR (0.X.0)
Incremented when new functionality is added in a backward-compatible manner.

Examples:
- New extension methods (e.g., MapAsync)
- Additional overloads
- Non-breaking enhancements

### PATCH (0.0.X)
Incremented for backward-compatible bug fixes only.

Examples:
- Bug fixes
- Performance improvements
- Internal refactoring without API impact

---

## Definition of Public API

The Public API includes:

- All public types in the `Resultify` namespace
- Public methods, properties, constructors, and extension methods
- Public records such as `Result`, `Result<T>`, and `Error`

Internal types and implementation details are not considered part of the public contract and may change without notice.

---

## Breaking Changes Policy

Breaking changes are introduced **only in MAJOR versions**.

When a breaking change is necessary:

1. It is clearly documented under a **"Breaking Changes"** section in `CHANGELOG.md`
2. A migration explanation is provided when applicable
3. Deprecated APIs may be marked with `[Obsolete]` before removal (when feasible)

Example deprecation strategy:

```csharp
[Obsolete("Use MapAsync instead. This method will be removed in v3.0.0.")]
```
## Deprecation Strategy

Whenever possible:

- APIs will first be marked as `[Obsolete]`.
- Obsolete APIs will remain available until the next MAJOR release.
- Obsolete APIs will be removed in the next MAJOR version.

Immediate removal may occur only when:

- The API is unsafe.
- The behavior is incorrect.
- The change is required for correctness or security.

---

## Compatibility Guarantees

- PATCH releases will never introduce breaking changes.
- MINOR releases will remain backward-compatible.
- MAJOR releases may introduce breaking changes and will include migration guidance.

---

## Pre-1.0 Behavior

Before version `1.0.0`:

- Breaking changes may occur in MINOR releases.
- The API should be considered evolving.
- Stability guarantees increase after `1.0.0`.

---

## Migration Guidance

For major version upgrades:

- Review the `CHANGELOG.md`.
- Look for the **"Breaking Changes"** section.
- Follow any documented migration instructions.