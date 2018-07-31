using DeviceManagement.Data;
using System.Linq;

namespace DeviceManagement.Business.Entities
{
    public class DeviceEntity
    {
        #region Attributes

        public int IdDevice { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int IdDeviceType { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that adds to the database the past device as a parameter.
        /// </summary>
        /// <param name="deviceEntity"></param>
        public static int Create(DeviceEntity deviceEntity)
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                var dbDevice = deviceEntity.MapToBD();

                dbContext.DEVICE.Add(dbDevice);
                dbContext.SaveChanges();

                return dbDevice.IdDevice;
            }
        }

        #endregion

        #region Internal Methods 

        internal int GetNextId()
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                var dbDevice = dbContext.DEVICE.OrderByDescending(x => x.IdDevice).FirstOrDefault();

                if (dbDevice == null)
                    return 1;

                return dbDevice.IdDevice + 1;
            }
        }


        /// <summary>
        /// Method that maps a device to the database model.
        /// </summary>
        /// <returns></returns>
        internal DEVICE MapToBD()
        {
            var dbDevice = new DEVICE
            {
                IdDevice = GetNextId(),
                SerialNumber = SerialNumber,
                Brand = Brand,
                Model = Model,
                IdDeviceType = IdDeviceType
            };

            return dbDevice;
        }

        /// <summary>
        /// Method that maps a device from a database model passed by parameter.
        /// </summary>
        /// <param name="dbDevice"></param>
        /// <returns></returns>
        internal static DeviceEntity MapFromBD(DEVICE dbDevice)
        {
            var deviceEntity = new DeviceEntity()
            {
                IdDevice = dbDevice.IdDevice,
                SerialNumber = dbDevice.SerialNumber,
                Brand = dbDevice.Brand,
                Model = dbDevice.Model,
                IdDeviceType = dbDevice.IdDeviceType
            };

            return deviceEntity;
        }

        #endregion
    }
}
