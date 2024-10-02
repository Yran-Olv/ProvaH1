using WebApplication1.Models;

namespace WebApplication1.Services

{
    public class ChurrascoRepository : IChurrascoRepository
    {
        private readonly List<Participante> _participantes = new();

        public void AdicionarParticipante(Participante participante)
        {
            _participantes.Add(participante);
        }

        public List<Participante> ListarParticipantes()
        {
            return _participantes;
        }
    }

}