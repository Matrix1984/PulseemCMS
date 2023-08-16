using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PulseemCMS.Application.Common.Models;
using PulseemCMS.Domain.Entities;

namespace PulseemCMS.Application.Clients.Commands.CreateClient;
public class CreateClientVM : Result
{
    internal CreateClientVM(bool succeeded, IEnumerable<string> errors) : base(succeeded, errors)
    {

    }

    public Client? Client { get; set; }
}
