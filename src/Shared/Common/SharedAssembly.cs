using System.Reflection;

namespace ExampleProject.Shared.Common;

public interface SharedAssembly
{
    static Assembly Assembly => typeof(SharedAssembly).Assembly;
}
