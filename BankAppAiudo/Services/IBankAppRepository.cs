using BankAppAiudo.Entities;
using BankAppAiudo.Helpers;
using BankAppAiudo.PersistenceModels;
using System.Collections.Generic;

namespace BankAppAiudo.Services
{
    public interface IBankAppRepository
    { //Todo: si queremos implementar las opciones de cuenta maestra, descomentarlas e implementarlas (realmente es casi como copiar las otras)
       //Todo: ídem, escribir las que no están escritas, es a partir de CRUD Movements. 
        #region CRUD Users
            #region Conceptualmente, la C de CRUD Users
            IUser CreateUser(string id, string password, double amount);
                #endregion

            #region Conceptualmente, la R de CRUD Users
                IUser GetUser(string id, string password);
                // IUser GetUserMaster(string id, string masterid, string masterpassword);
                #endregion

            #region Conceptualmente, la U de CRUD Users
                IUser UpdatePassword(string id, string password, string newpassword);
                // IUser UpdateUserMaster(string id, string masterid, string masterpassword, IUser reneweduser);
                #endregion

            #region Conceptualmente, la D de CRUD Users
                void DeleteUser(string id, string password);
        // IUser DeleteUserMaster(string id, string masterid, string masterpassword);
        #endregion
        #endregion


        #region CRUD Movements

        #region Create Movements
        Transferencia TransferMoney(string destination, string responsibleId, string responsiblepassword, string concepto, string message, double amount);
        Prestamo AskForALoan(string origin, string responsibleId, string responsiblepassword,  string concepto, string message, double amount);
        //Todo: realmente cuando pides un préstamo siempre viene de la misma cuenta. Así que se podría quitar de la invocación del método para hacerlo más ligero.
        #endregion

        //Todo: poner en el controlador un método que sea ejecutar deuda, que llame a TransferMoney y lo rellene solo, de manera que se cobren las deudas.

        #region Read Movements
        List<IMovimiento> GetHistory(string id, string password);
        // List<IMovimiento> GetHistoryMaster(string id, string masterid, string masterpassword);
        List<Debt> GetDebts(string id, string password);
        // List<Debt> GetDebtsMaster(string id, string password);
        #endregion

        #region Update Movements ??? //Todo

        #endregion

        #region Delete Movements //Todo
        #endregion


        #endregion


        Cliente FillUser(Cliente client);
    }
}