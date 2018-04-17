

namespace mktDB
{
    class MKCliCargoVM : VMBase
    {
        public mkCliCargo ThemkCliCargo { get; set; }
        public MKCliCargoVM()
        {
            // Initialise the entity or inserts will fail
            ThemkCliCargo = new mkCliCargo();
            ThemkCliCargo.CliCargoValue = "Prueba";
        }
    }
    
}
