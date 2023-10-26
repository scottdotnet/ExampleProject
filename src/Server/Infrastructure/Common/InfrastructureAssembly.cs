using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Infrastructure.Common;

public interface InfrastructureAssembly
{
    static Assembly Assembly => typeof(InfrastructureAssembly).Assembly;
}
