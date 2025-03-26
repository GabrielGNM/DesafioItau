using DesafioItaú.Dto;

namespace DesafioItaú
{
    public class TransacaoSingleton
    {
        private static TransacaoSingleton? _instance;
        private List<TrasacaoDto> _transacoes;

        public TransacaoSingleton()
        {
            _transacoes = [];
        }

        public static TransacaoSingleton Instance
        {
            get
            {
                _instance ??= new TransacaoSingleton();
                return _instance;
            }
        }

        public List<TrasacaoDto> Transacoes => _transacoes;
    }
}