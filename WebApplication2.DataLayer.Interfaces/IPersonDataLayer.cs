namespace WebApplication2.DataLayerInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPersonDataLayer
    {
        string CreateRecord(string record);

        IEnumerable<string> GetTextData();
    }
}
