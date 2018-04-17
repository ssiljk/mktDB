using mktDB.Support;

namespace mktDB.ViewModel.RowVM
{
    class MKClienteVM : VMBase
    {
        public mkCliente ThemkCliente { get; set; }
        public MKClienteVM()
        {
            ThemkCliente = new mkCliente();
        }
    }
}
