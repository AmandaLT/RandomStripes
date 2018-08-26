using System.Collections.Generic;

namespace RandomStripes
{
    public interface IApplicationWrapper
    {
        IDictionary<string, object> Properties { get; }
    }
}