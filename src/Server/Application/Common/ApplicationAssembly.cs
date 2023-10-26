using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Server.Application.Common;

public interface ApplicationAssembly
{
    static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
}
