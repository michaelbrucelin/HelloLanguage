using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigServices
{
    /// <summary>
    /// 实现类可以考虑在其它项目中创建，这里图省事直接创建在类库项目中
    /// </summary>
    public class EnvVarConfigService : IConfigService
    {
        public string GetValue(string name)
        {
            return Environment.GetEnvironmentVariable(name) ?? $"{name}_not_found";
        }
    }
}
