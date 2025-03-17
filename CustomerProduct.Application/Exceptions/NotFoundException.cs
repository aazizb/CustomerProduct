using System.Xml.Linq;

namespace CustomerProduct.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base(($"{name} ({key}) not found")) { }
    }
}
