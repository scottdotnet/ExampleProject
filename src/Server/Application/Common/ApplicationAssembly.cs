using System.Reflection;

namespace ExampleProject.Server.Application.Common;

public interface ApplicationAssembly
{
    static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
}
