# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ASP.NET Core 6 MVC student management app with in-memory data storage. Data is stored in a static `List<Student>` in the `StudentController` and resets on application restart — **no database, no EF Core, no DbContext, no migrations**.

## Build & Run

```bash
dotnet build
dotnet run                              # Starts at http://localhost:5264
dotnet run --launch-profile ThuStudent  # Explicit launch profile
```

No test framework configured — no unit tests exist.

## Architecture

- **Pattern**: MVC with no service or repository layer. All CRUD logic lives directly in controllers.
- **Data Storage**: In-memory `static List<Student>` in `StudentController` (line 8). Do not introduce database layers or persistence unless explicitly requested.
- **Routing**: Convention-based routing with default route `{controller=Student}/{action=Index}/{id?}`. The landing page is `Student/Index`, not `Home/Index`.
- **Validation**: Data annotations on the `Student` model (`[Required]`, `[StringLength]`, `[RegularExpression]`). Views use jQuery validation for client-side checks.

## Student Model Fields

- `Id` — required int (manually entered by user, not auto-incremented)
- `Name` — required, max 100 characters
- `Email` — optional, regex-validated
- `Phone` — optional, max 10 characters

## Code Conventions

- C# 10 with nullable reference types and implicit usings enabled
- Model properties use the `virtual` keyword
- Follow ASP.NET MVC naming: `{Entity}Controller`, views at `Views/{Controller}/{Action}.cshtml`
- Use `@Html.ActionLink` and `asp-*` tag helpers in Razor views
- Include `_ValidationScriptsPartial` in forms for client-side validation

## Known Issues

- **Missing server-side validation**: `Create` and `Edit` POST actions in [StudentController.cs:16,36](Controllers/StudentController.cs#L16) lack `ModelState.IsValid` checks — validation annotations won't block invalid data server-side
- `HomeController1.cs` is an unused scaffold (safe to delete)
- Swashbuckle package is installed but unused (no API endpoints defined)
