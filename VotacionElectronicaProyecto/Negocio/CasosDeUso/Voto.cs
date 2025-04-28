using Shared.Dtos.Voto;

namespace Negocio.CasosDeUso
{
    public static class Voto
    {
        public static async Task RegistrarVoto(CrearDTO votoDto)
        {
            ArgumentNullException.ThrowIfNull(votoDto, nameof(votoDto));

            if (votoDto.EleccionId <= 0)
                throw new ArgumentException("EleccionId debe ser mayor a cero.", nameof(votoDto.EleccionId));

            if (votoDto.ListaId <= 0)
                throw new ArgumentException("ListaId debe ser mayor a cero.", nameof(votoDto.ListaId));

            // Llama al método del repositorio para registrar el voto
            await Repositorio.Voto.RegistrarVoto(votoDto);
        }
    }
}
