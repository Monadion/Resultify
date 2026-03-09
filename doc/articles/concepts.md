# Concepts

Resultify is a lightweight library that implements the **Result pattern** for C#.

Instead of relying on exceptions for control flow, Resultify models **success and failure explicitly** using dedicated result types. This approach makes error handling more predictable, composable, and easier to read.


## Result types

Resultify provides two core types:

- **`Result`**  
  Represents an operation that either succeeds or fails but does **not return a value**.

- **`Result<T>`**  
  Represents an operation that either succeeds with a value of type `T` or fails with an error.

Using these types standardizes how operations report their outcome and ensures callers handle both success and failure explicitly.

## Error

Failures are represented by an **`Error` record**.

An `Error` describes **why an operation failed** and allows callers to react to failures in a controlled way using operations such as `Match`.

This makes failure handling explicit rather than hidden inside exception handling logic.


## Functional pipelines

Resultify is designed for **fluent functional pipelines**.

Operations can be chained together to build a clear execution flow.

Key operations include:

- **`Try(...)`**  
  Executes a function that may throw and converts the result into a `Result` or `Result<T>`.

- **`Map(...)`**  
  Transforms the successful value while preserving the result structure.

- **`Bind(...)`**  
  Chains operations that themselves return `Result` values, allowing complex workflows to be composed.

- **`Match(onSuccess, onFailure)`**  
  Handles both success and failure cases and produces the final result.

This approach replaces scattered `try/catch` blocks with a **clear and composable execution pipeline**.

## Exception handling

Resultify does **not eliminate exceptions**, but it encourages avoiding them for normal control flow.

Instead, potentially failing operations are wrapped using `Try`, which converts exceptions into `Result` values.

This makes error propagation explicit and visible in method signatures.

## When to use Resultify

Resultify is useful when:

- building **service pipelines** (parse → validate → transform → persist)
- you want **explicit error handling**
- you want to avoid hidden control flow caused by exceptions
- composing multiple operations into a **predictable workflow**

## When not to use it

Resultify may not be necessary when:

- your project relies heavily on **exception-based control flow**
- the operation is extremely simple and a result pipeline would add unnecessary complexity

As always, choose the approach that best fits your team's coding style and architecture.
