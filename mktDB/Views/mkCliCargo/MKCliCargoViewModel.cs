using System;
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

namespace mktDB
{
    class MKCliCargoViewModel : CrudVMBase
    {
        public MKCliCargoVM SelectedmkCliCargo { get; set; }
        public ObservableCollection<MKCliCargoVM> MKCliCargos { get; set; }
        public MKCliCargoViewModel() : base()
        {

        }
        protected override void CommitUpdates()
        {
            UserMessage msg = new UserMessage();
            var inserted = (from c in MKCliCargos
                            where c.IsNew
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (MKCliCargoVM c in inserted)
                {
                    db.mkCliCargo.Add(c.ThemkCliCargo);
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
            if (SelectedmkCliCargo != null)
            {
                int NumOrders = NumberOfContactos();
                if (NumOrders > 0)
                {
                    msg.Message = string.Format("Cannot delete - there are {0} Orders for this Customer", NumOrders);
                }
                else
                {
                    db.mkCliCargo.Remove(SelectedmkCliCargo.ThemkCliCargo);
                    MKCliCargos.Remove(SelectedmkCliCargo);
                    RaisePropertyChanged("MKCliCargo");
                    msg.Message = "Borrado";
                }
            }
            else
            {
                msg.Message = "No hay CliCargo seleccionado para borrar";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }

        private int NumberOfContactos()
        {
            var cust = db.mkCliCargo.Find(SelectedmkCliCargo.ThemkCliCargo.mkCliCargoId);
            // Cuenta cuantos contactos tiene el CliCargo
            int contactosCount = db.Entry(cust)
                                .Collection(c => c.mkContacto)
                                .Query()
                                .Count();
            return contactosCount;
        }
        protected async override void GetData()
        {
            ThrobberVisible = Visibility.Visible;
            ObservableCollection<MKCliCargoVM> _CliCargos = new ObservableCollection<MKCliCargoVM>();
            try
            {
                var mkCliCargos = await (from c in db.mkCliCargo
                                        orderby c.CliCargoValue
                                        select c).ToListAsync();
                //  await Task.Delay(9000);
                foreach (mkCliCargo cust in mkCliCargos)
                {
                    _CliCargos.Add(new MKCliCargoVM { IsNew = false, ThemkCliCargo = cust });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception{0}", ex);
            }
            MKCliCargos = _CliCargos;
            RaisePropertyChanged("MKCliCargo");
            ThrobberVisible = Visibility.Collapsed;
        }
    }
}
