using System.Reflection;

namespace ExampleProject.Server.Infrastructure.Common;

public interface InfrastructureAssembly
{
    static Assembly Assembly => typeof(InfrastructureAssembly).Assembly;
}
