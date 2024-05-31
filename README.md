# EXAM

# Generate db migrations

~~~bash
# install or update
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

# create migration
dotnet ef migrations add Initial --project App.DAL.EF --startup-project WebApp --context AppDbContext 
dotnet ef migrations add Token --project App.DAL.EF --startup-project WebApp --context AppDbContext 

# apply migration
dotnet ef database update --project App.DAL.EF --startup-project WebApp --context AppDbContext 
~~~


# generate rest controllers

Add nuget packages
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.EntityFrameworkCore.SqlServer

~~~bash
# install tooling
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update --global dotnet-aspnet-codegenerator
~~~

~~~bash
cd WebApp

dotnet aspnet-codegenerator controller -name SubjectsController -actions -m  App.Domain.Subject -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name HomeworksController -actions -m  App.Domain.Homework -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name RolesController -actions -m  App.Domain.Role -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserSubjectsController -actions -m  App.Domain.UserSubject -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserSubjectHomeworksController -actions -m  App.Domain.UserSubjectHomework -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

cd ..
~~~
~~~bash
cd WebApp

dotnet aspnet-codegenerator controller -name SubjectsController  -m  App.Domain.Subject        -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name HomeworksController -m  App.Domain.Homework -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name RolesController -m  App.Domain.Role -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name UserSubjectsController -m  App.Domain.UserSubject -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name UserSubjectHomeworksController -m  App.Domain.UserSubjectHomework -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

cd ..
~~~

