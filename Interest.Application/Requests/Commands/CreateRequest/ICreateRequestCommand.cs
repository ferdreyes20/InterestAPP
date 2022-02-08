using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Commands.CreateRequest
{
    public interface ICreateRequestCommand
    {
        int Execute(decimal value);
    }
}
