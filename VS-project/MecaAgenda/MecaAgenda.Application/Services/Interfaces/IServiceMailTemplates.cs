using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Interfaces
{
    public interface IServiceMailTemplates
    {
        Task<string> GetEmailTemplate(string templateName);
    }
}
