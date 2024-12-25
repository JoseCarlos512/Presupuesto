// using Presupuestos.Domain.Usuarios;

namespace Presupuestos.Application.Abstractions.Email;

    public interface IEmailService
    {
        Task SendAsnyc(string correoElectronico, string subject, string body);
    }
