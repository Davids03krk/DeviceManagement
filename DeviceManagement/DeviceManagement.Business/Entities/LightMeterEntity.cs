using DeviceManagement.Data;
using System;
using System.Linq;

namespace DeviceManagement.Business.Entities
{
    public class LightMeterEntity
    {
        #region Attributes

        public int IdDevice { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that returns the device of type light meter with the Id passed as parameter. 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static LightMeterEntity Load(int deviceId)
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                var dbLightMeter = dbContext.LIGHT_METER.Find(deviceId);

                if (dbLightMeter == null)
                    return null;

                return MapFromBD(dbLightMeter);
            }
        }

        /// <summary>
        /// Method that adds to the database the past device of type light meter as a parameter.
        /// </summary>
        /// <param name="lightMeterEntity"></param>
        public static void Create(LightMeterEntity lightMeterEntity)
        {
            try
            {
                using (var dbContext = new DeviceManagementEntities())
                {
                    var dbLightMeter = lightMeterEntity.MapToBD();

                    dbContext.LIGHT_METER.Add(dbLightMeter);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                DeviceEntity.Delete(lightMeterEntity.IdDevice);
                throw new Exception("Error.There was a problem when inserting data from a light meter in the database");
            }
        }

        #endregion

        #region Internal Methods 

        /// <summary>
        /// Method that maps a device of type light meter to the database model.
        /// </summary>
        /// <returns></returns>
        internal LIGHT_METER MapToBD()
        {
            var dbLightMeter = new LIGHT_METER
            {
                IdDevice = IdDevice
            };

            return dbLightMeter;
        }

        /// <summary>
        /// Method that maps a device of type light meter from a database model passed by parameter.
        /// </summary>
        /// <param name="dbLightMeter"></param>
        /// <returns></returns>
        internal static LightMeterEntity MapFromBD(LIGHT_METER dbLightMeter)
        {
            var lightMeterEntity = new LightMeterEntity()
            {
                IdDevice = dbLightMeter.IdDevice
            };

            return lightMeterEntity;
        }

        #endregion
    }
}
