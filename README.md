# Unity Async Bridge

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE.md)  
![Unity Version](https://img.shields.io/badge/Unity-2020.3+-black.svg)

Unified async API for cross-platform Unity projects.

## Documentation
- [Installation](Documentation/Installation.md)
- [Usage Examples](Documentation/Usage.md)
- [API Reference](Documentation/API.md)
- [Platform Support](Documentation/Platforms.md)

## License
See [LICENSE.md](LICENSE.md)

# Installation

## Dependencies
- **UniTask** (required for WebGL):
  ```sh
  https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask

  
---

### 3. **Usage.md** (`/Documentation/Usage.md`)
```markdown
# Usage Examples

## Basic Operation
```csharp
// Task example
var operation = AsyncOperationFactory.Create(async (ct) => 
{
    await Task.Delay(1000, ct);
});


---

### 4. **API.md** (`/Documentation/API.md`)
```markdown
# API Reference

## Interfaces
| Interface | Description |
|-----------|-------------|
| `IAsyncOperation` | Core awaitable contract |

## Factory
```csharp
// For Task
Create(Func<CancellationToken, Task>)


---

### 5. **Platforms.md** (`/Documentation/Platforms.md`)
```markdown
# Platform Support

| Platform | Implementation |
|----------|----------------|
| WebGL    | UniTask        |
| Others   | Task           |
