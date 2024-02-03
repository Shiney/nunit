// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System.Collections.Generic;

namespace NUnit.Framework.Internal.Execution
{
    public class DependenciesInfo
    {
        List<string> _dependencies = new List<string>();
        public void AddDependency(string dependency)
        {
            _dependencies.Add(dependency);
        }
    }
}
