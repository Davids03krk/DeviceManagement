using DeviceManagement.Data;
using System.Linq;

namespace DeviceManagement.Business.Entities
{
    public class GatewayEntity
    {
        #region Attributes

        public int IdDevice { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that returns the device of type gateway with the Id passed as parameter. 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public static GatewayEntity Load(int deviceId)
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                var dbGateway = dbContext.GATEWAY.Find(deviceId);

                if (dbGateway == null)
                    return null;

                return MapFromBD(dbGateway);
            }
        }

        /// <summary>
        /// Method that adds to the database the past device of type gateway as a parameter.
        /// </summary>
        /// <param name="gatewayEntity"></param>
        public static void Create(GatewayEntity gatewayEntity)
        {
            using (var dbContext = new DeviceManagementEntities())
            {
                var dbGateway = gatewayEntity.MapToBD();

                dbContext.GATEWAY.Add(dbGateway);
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
        /// Method that maps a device of type gateway to the database model.
        /// </summary>
        /// <returns></returns>
        internal GATEWAY MapToBD()
        {
            var dbGateway = new GATEWAY
            {
                IdDevice = IdDevice,
                Ip = Ip,
                Port = Port
            };

            return dbGateway;
        }

        /// <summary>
        /// Method that maps a device of type gatewat from a database model passed by parameter.
        /// </summary>
        /// <param name="dbGateway"></param>
        /// <returns></returns>
        internal static GatewayEntity MapFromBD(GATEWAY dbGateway)
        {
            var gatewayEntity = new GatewayEntity()
            {
                IdDevice = dbGateway.IdDevice,
                Ip = dbGateway.Ip,
                Port = dbGateway.Port
            };

            return gatewayEntity;
        }

        #endregion
    }
}
