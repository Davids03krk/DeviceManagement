using DeviceManagement.Business.Entities;
using DeviceManagement.Business.Functions;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Model.Device
{
    public class GatewayModel : TypeDeviceModel
    {
        #region Properties

        [Required]
        public string Ip { get; set; }
        public string Port { get; set; }

        #endregion

        #region Public Methods

        public static GatewayModel FromEntity(GatewayEntity gatewayEntity)
        {
            var gatewayModel = new GatewayModel()
            {
                IdDevice = gatewayEntity.IdDevice,
                Ip = gatewayEntity.Ip,
                Port = gatewayEntity.Port,
                TypeDevice = Enumerators.DeviceTypes.GATEWAY
            };

            return gatewayModel;
        }

        public GatewayEntity ToEntities()
        {
            var gatewayEntity = new GatewayEntity()
            {
                IdDevice = IdDevice,
                Ip = Ip,
                Port = Port
            };

            return gatewayEntity;
        }

        #endregion
    }
}
