using MecaAgenda.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.Implementations
{
    public class ServiceMailTemplates : IServiceMailTemplates
    {
        public async Task<string> GetEmailTemplate(string templateName)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "email-templates", templateName);
            return await File.ReadAllTextAsync(path);
        }
    }
}
