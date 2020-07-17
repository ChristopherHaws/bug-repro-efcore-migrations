Repro Steps:
```powershell
cd ./EFCoreMigrationUpdateData
dotnet tool restore
dotnet ef migrations add NothingChanged
dotnet ef migrations add NothingChange2
```

Notice that the `NothingChange2` migration has updates to seed data when nothing has changed.