using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Requests.Commands.UpdateRequest
{
    public interface IUpdateRequestCommand
    {
        int Execute(UpdateRequestModel request);
    }
}
