using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Serie_Console.Interfaces
{
    public interface IRepositorio<Catalogo>
    {
        List<Catalogo> Lista();
        Catalogo RetornaPorId(int id);
        void Insere(Catalogo entidade);
        void Exclui(int id);
        void Atualiza(int id, Catalogo entidade);
        int ProximoId();
    }
}
