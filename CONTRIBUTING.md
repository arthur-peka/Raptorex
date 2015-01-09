# Contributing

Bugfixes are very welcome, however please open an issue before contributing a new feature.

## Coding standards and naming conventions

### General

TBA

### Entity Framework

* Use Annotations over Fluent API. The reason is to reuse annotations for server-side validation.

## Tools

Currently, the following tools are needed for a comfortable work with the project:
* Visual Studio 2013
* MS SQL Server Management Studio - not 100% mandatory, I'm using LocalDb which comes with VS. *However*, there's a known bug,
when you can't drop your LocalDb database even when you delete the actual database file. Most robust way I know is to drop it
from SQL Management Studio.
