---
description: "Fix known issues: remove unused scaffold controller, remove unused Swashbuckle package, and add ModelState validation to Create/Edit POST actions"
agent: "agent"
---

Fix all known issues in this project. Work through each item below, verify the current state, and skip any that are already resolved.

## 1. Delete unused `HomeController1.cs`

[HomeController1.cs](../../Controllers/HomeController1.cs) is an empty scaffold — no views reference it and no routes depend on it. Delete the file.

## 2. Remove unused Swashbuckle NuGet package

[ThuStudent.csproj](../../ThuStudent.csproj) includes `Swashbuckle.AspNetCore` but the project has no API endpoints. Remove the `<PackageReference>` for Swashbuckle and run `dotnet restore`.

## 3. Add `ModelState.IsValid` checks to POST actions

[StudentController.cs](../../Controllers/StudentController.cs) `Create` and `Edit` POST actions should check `ModelState.IsValid` before modifying data. If invalid, return the view with the current model so validation messages display. Example pattern:

```csharp
[HttpPost]
public IActionResult Create(Student student)
{
    if (!ModelState.IsValid)
        return View(student);
    // ... proceed with adding
}
```

## 4. Verify and build

After all changes, run `dotnet build` to confirm the project compiles without errors.
