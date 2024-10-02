using WebApplication1.Models;

namespace WebApplication1.Services
{

    public interface IChurrascoRepository
    {
        void AdicionarParticipante(Participante participante);
        List<Participante> ListarParticipantes();
    }
}