# PatternMastery
[![.NET 8](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/download)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](./LICENSE)
[![Build](https://github.com/borispanasenko/PatternMastery/actions/workflows/dotnet.yml/badge.svg)](https://github.com/borispanasenko/PatternMastery/actions/workflows/dotnet.yml)


A modular collection of algorithmic patterns and data manipulation techniques implemented in C# for .NET 8.  
PatternMastery provides clean, tested, and benchmarked reference implementations of commonly used problem-solving strategies.

This repository is suitable for:
- Engineers strengthening fundamental algorithmic thinking
- Teams developing shared algorithmic utilities
- Researchers evaluating performance trade-offs
- Educational use, workshops, and interview preparation

---

## Features

- **Consistent, idiomatic .NET implementations**
- **Pattern-first organization** (not problem-first)
- **xUnit test coverage across all modules**
- **BenchmarkDotNet performance benchmarking**
- **Playground environment for interactive exploration**

---

## Project Structure

```
src/                      # Core implementation libraries
│
├─ Foundations/           # Two-pointers, scanning, partitioning, etc.
├─ HashingLinear/         # Hash maps, frequency analysis, deduplication
├─ Structural/            # Structural composition and helper utilities
└─ TraversalRecursion/    # Recursive and traversal strategies

tests/                    # xUnit test suite
benchmarks/               # BenchmarkDotNet performance analysis
playground/               # Interactive demo console

```

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Restore, Build, and Test

```bash
dotnet restore
dotnet build -c Release
dotnet test -c Release
```

---

## Benchmarks

BenchmarkDotNet is used to measure performance trade-offs between algorithmic variations.

```bash
dotnet run -c Release --project benchmarks/PatternMastery.Benchmarks
```

Benchmark reports are generated under:

```
BenchmarkDotNet.Artifacts/results/
```

---

## Playground (Optional)

```bash
dotnet run --project playground/PatternMastery.Playground
```

Use this to:

* Interactively explore pattern behavior
* Compare algorithmic variants side-by-side
* Experiment before integrating into production code

---

## Quality & Standards

* .NET naming & formatting conventions
* **StyleCop** static analysis rules (`stylecop.json`)
* Deterministic builds & source-linked debugging

---

## Roadmap

| Area                                 |     Status     | Notes                         |
| ------------------------------------ | :------------: | ----------------------------- |
| Foundations (Two-Pointers, Scanning) |   ✅ Complete   | Benchmarked + tested          |
| HashingLinear (Maps/Sets/Lookup)     |   ✅ Complete   | Stable                        |
| Structural Utilities                 | 🔄 In Progress | Expanding coverage            |
| Traversal & Recursion Patterns       | 🔄 In Progress | Further optimizations planned |
| Visualization / Documentation Site   |   🟡 Planned   | GitHub Pages                  |

---

## Contributing

Contributions are welcome.
Please open an Issue for design-level discussions.

Before submitting:

```bash
dotnet test -c Release
```

Ensure StyleCop formatting rules are satisfied.

---

## License

**MIT License**
You are free to use this code in commercial and open-source projects.