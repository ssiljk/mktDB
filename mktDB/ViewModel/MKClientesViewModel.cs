using System;
using mktDB.Support;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Threading;
using mktDB.Messages;
using mktDB.ViewModel.RowVM;



namespace mktDB.ViewModel
{
    class MKClientesViewModel : CrudVMBase
    {
        public MKClienteVM SelectedmkCliente { get; set; }
        public ObservableCollection<MKClienteVM> MKClientes { get; set; }
        public MKClientesViewModel() : base()
        {

        }
        protected override void CommitUpdates()
        {
            UserMessage msg = new UserMessage();
            var inserted = (from c in MKClientes
                            where c.IsNew
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (MKClienteVM c in inserted)
                {
                    db.mkCliente.Add(c.ThemkCliente);
                }
                try
                {
                    db.SaveChanges();
                    msg.Message = "Base de Datos actualizada";
                }
                catch (Exception e)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        ErrorMessage = e.InnerException.GetBaseException().ToString();
                    }
                    msg.Message = "Hubo un problema actualizando la Base de Datos";
                }
            }
            else
            {
                msg.Message = "No hay cambios para guardar";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }
        protected override void DeleteCurrent()
        {
            UserMessage msg = new UserMessage();
            if (SelectedmkCliente != null)
            {
                int NumOrders = NumberOfContactos();
                if (NumOrders > 0)
                {
                    msg.Message = string.Format("Cannot delete - there are {0} Orders for this Customer", NumOrders);
                }
                else
                {
                    db.mkCliente.Remove(SelectedmkCliente.ThemkCliente);
                    MKClientes.Remove(SelectedmkCliente);
                    RaisePropertyChanged("MKClientes");
                    msg.Message = "Borrado";
                }
            }
            else
            {
                msg.Message = "No hay cliente seleccionado para borrar";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }

        private int NumberOfContactos()
        {
            var cust = db.mkCliente.Find(SelectedmkCliente.ThemkCliente.mkClienteId);
            // Cuenta cuantos contactos tiene el cliente
            int ordersCount = db.Entry(cust)
                                .Collection(c => c.mkContacto)
                                .Query()
                                .Count();
            return ordersCount;
        }
        protected async override void GetData()
        {
            ThrobberVisible = Visibility.Visible;
            ObservableCollection<MKClienteVM> _clientes = new ObservableCollection<MKClienteVM>();
            try
            {
                var mkClientes = await (from c in db.mkCliente
                                        orderby c.RazonSocial
                                        select c).ToListAsync();
                //  await Task.Delay(9000);
                foreach (mkCliente cust in mkClientes)
                {
                    _clientes.Add(new MKClienteVM { IsNew = false, ThemkCliente = cust });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception{0}", ex);
            }
            MKClientes = _clientes;
            RaisePropertyChanged("MKClientes");
            ThrobberVisible = Visibility.Collapsed;
        }
    }
}
