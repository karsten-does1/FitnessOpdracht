using FitnessBL.Interfaces;
using FitnessDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly GymTestContext _context;

        public EquipmentService(GymTestContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipment> GetAllEquipment()
        {
            return _context.Equipment.ToList();
        }

        public Equipment GetEquipmentById(int id)
        {
            return _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
        }

        public void AddEquipment(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
        }

        public void UpdateEquipment(int id, Equipment equipment)
        {
            var existingEquipment = _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
            if (existingEquipment == null)
                throw new KeyNotFoundException("Equipment not found.");

            existingEquipment.DeviceType = equipment.DeviceType;
            existingEquipment.IsInMaintenance = equipment.IsInMaintenance;

            _context.SaveChanges();
        }

        public void DeleteEquipment(int id)
        {
            var equipment = _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
            if (equipment == null)
                throw new KeyNotFoundException("Equipment not found.");

            _context.Equipment.Remove(equipment);
            _context.SaveChanges();
        }

        public void SetMaintenance(int id, bool isInMaintenance)
        {
            var equipment = _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
            if (equipment == null)
                throw new KeyNotFoundException("Equipment not found.");

            equipment.IsInMaintenance = isInMaintenance;
            _context.SaveChanges();
        }
    }
}

