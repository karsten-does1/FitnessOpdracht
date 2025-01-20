using FitnessDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<Equipment> GetAllEquipment();
        Equipment GetEquipmentById(int id);
        void AddEquipment(Equipment equipment);
        void UpdateEquipment(int id, Equipment equipment);
        void DeleteEquipment(int id);
        void SetMaintenance(int id, bool isInMaintenance);
    }
}
