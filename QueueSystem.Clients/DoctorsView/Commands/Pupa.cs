using System.Collections.Generic;

namespace DoctorsView.Commands
{
    internal class Pupa
    {
        private readonly IEnumerable<int> jakaLista;

        public Pupa(IEnumerable<int> jakaLista)
        {
            this.jakaLista = jakaLista;
        }
    }
}