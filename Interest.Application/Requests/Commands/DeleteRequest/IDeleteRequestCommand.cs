using Interest.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Commands.DeleteRequest
{
    public interface IDeleteRequestCommand
    {
        int Execute(int id);
    }
}
