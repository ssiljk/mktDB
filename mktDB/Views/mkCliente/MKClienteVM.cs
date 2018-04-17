

namespace mktDB
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
