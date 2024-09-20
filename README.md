# ConsoleLoggingStylesDemo
```
Using various styles to setup logging in console applications
```

In this demo, i m using various styles in order to setup logging in console applications.

>
- Example01 : based on ConfigureLogging method (the recommended way)
>
- Example02 : based on AddLogging method
>
- Example03 : based on LoggerFactory class
>

| Feature                               | **ConfigureLogging**                                      | **AddLogging**                                         | **Manual LoggerFactory**                             |
|---------------------------------------|-----------------------------------------------------------|--------------------------------------------------------|-----------------------------------------------------|
| **Purpose**                           | Configure logging globally for the entire application      | Configure logging for specific services within DI       | Manual logger factory creation and injection        |
| **Where used**                        | In the `Host` configuration                                | Inside `ConfigureServices` within the DI container      | Manually outside the `Host` configuration           |
| **Scope**                             | Global (affects all components and services)               | Service-specific (affects only DI-registered services)  | Service-specific (requires manual logger injection) |
| **Ease of Use**                       | Simple and centralized                                     | Slightly more involved, but flexible                    | Most complex (manual creation and management)       |
| **Control Level**                     | Moderate control, works well for global configurations     | Fine-grained control over logging for specific services | Full control, but requires manual setup and cleanup |
| **Disposal of Logger Factory**        | Handled by the `Host`                                      | Handled by the `Host`                                   | Must be manually disposed                           |
| **Flexibility**                       | Limited to global configurations                           | Flexible for different services                         | Highly flexible for custom setups                   |
| **Best Use Case**                     | When you want global, consistent logging                   | When services require different logging setups          | When you need full control over logging behavior     |

**`Tools`** : net 8.0
