# Project Guidelines

## Overview

ASP.NET Core 6 MVC student management app with in-memory data storage. No database — data lives in a static `List<Student>` and resets on restart.

## Architecture

- **Pattern**: MVC (no service/repository layer). CRUD logic lives directly in controllers.
- **Data**: In-memory `static List<Student>` in `StudentController`. No EF Core, no DbContext, no migrations.
- **Routing**: Convention-based `{controller=Student}/{action=Index}/{id?}` — the default landing page is `Student/Index`, not `Home/Index`.
- **Validation**: Data annotations on `Student` model (`[Required]`, `[StringLength]`, `[RegularExpression]`).
- **Views**: Razor with tag helpers and Bootstrap 5. jQuery validation for client-side validation.

## Build and Test

```bash
dotnet build
dotnet run                              # http://localhost:5264
dotnet run --launch-profile ThuStudent  # explicit profile
```

No unit tests exist. No test project configured.

## Code Style

- C# 10 with nullable reference types and implicit usings enabled.
- Follow standard ASP.NET MVC naming: `{Entity}Controller`, views in `Views/{Controller}/{Action}.cshtml`.
- Model properties use `virtual` keyword.
- Use data annotations for validation — not FluentValidation.

## Conventions

- **No database**: All data operations use the static `List<Student>` in `StudentController`. Do not introduce EF Core or a database context unless explicitly asked.
- **ID management**: IDs are manually entered by the user (no auto-increment).
- **Student model fields**: `Id` (required int), `Name` (required, max 100), `Email` (optional, regex-validated), `Phone` (optional, max 10).
- **Views**: Use `@Html.ActionLink` and `asp-*` tag helpers. Include `_ValidationScriptsPartial` for forms.

## Known Issues

- `HomeController1.cs` is an unused scaffold — safe to delete.
- Swashbuckle NuGet package is installed but unused (no API endpoints).
- `Create` and `Edit` POST actions lack `ModelState.IsValid` checks — validation annotations on the model won't block bad data server-side.
