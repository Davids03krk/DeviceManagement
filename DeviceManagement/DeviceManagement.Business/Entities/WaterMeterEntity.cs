using DeviceManagement.Data;
using System.Linq;

namespace DeviceManagement.Business.Entities
{
    public class WaterMeterEntity
    {
        #region Attributes

        public int IdDevice { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that returns the device of type water meter with the Id passed as parameter. 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static WaterMeterEntity Load(int deviceId)
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                var dbWaterMeter = dbContext.WATER_METER.Find(deviceId);

                if (dbWaterMeter == null)
                    return null;

                return MapFromBD(dbWaterMeter);
            }
        }

        /// <summary>
        /// Method that adds to the database the past device of type water meter as a parameter.
        /// </summary>
        /// <param name="waterMeterEntity"></param>
        public static void Create(WaterMeterEntity waterMeterEntity)
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                var dbWaterMeter = waterMeterEntity.MapToBD();

                dbContext.WATER_METER.Add(dbWaterMeter);
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region Internal Methods 

        ///// <summary>
        ///// Method that returns if the current device exists in the database.
        ///// </summary>
        ///// <returns></returns>
        internal bool Exist()
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                return dbContext.DEVICE.Any(x => x.IdDevice == IdDevice);
            }
        }

        /// <summary>
        /// Method that maps a device of type water meter to the database model.
        /// </summary>
        /// <returns></returns>
        internal WATER_METER MapToBD()
        {
            var dbWaterMeter = new WATER_METER
            {
                IdDevice = IdDevice
            };

            return dbWaterMeter;
        }

        /// <summary>
        /// Method that maps a device of type water meter from a database model passed by parameter.
        /// </summary>
        /// <param name="dbWaterMeter"></param>
        /// <returns></returns>
        internal static WaterMeterEntity MapFromBD(WATER_METER dbWaterMeter)
        {
            var waterMeterEntity = new WaterMeterEntity()
            {
                IdDevice = dbWaterMeter.IdDevice
            };

            return waterMeterEntity;
        }

        #endregion
    }
}
