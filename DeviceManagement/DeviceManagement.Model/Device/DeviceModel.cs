using DeviceManagement.Business.Entities;
using DeviceManagement.Business.Functions;
using System;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Model.Device
{
    public class DeviceModel
    {
        #region Properties

        public int IdDevice { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Required]
        public Enumerators.DeviceTypes TypeDeviceValue { get; set; }
        [Required]
        public TypeDeviceModel TypeDeviceData { get; set; }

        #endregion

        #region Public Methods

        public static DeviceModel FromEntity(DeviceEntity deviceEntity)
        {
            var deviceModel = new DeviceModel()
            {
                IdDevice = (int)deviceEntity.IdDevice,
                SerialNumber = deviceEntity.SerialNumber,
                Brand = deviceEntity.Brand,
                Model = deviceEntity.Model,
                TypeDeviceValue = (Enumerators.DeviceTypes)Enum.Parse(typeof(Enumerators.DeviceTypes), deviceEntity.IdDeviceType.ToString())
            };

            deviceModel.TypeDeviceData = GetTypeDeviceData(deviceModel.TypeDeviceValue, deviceModel.IdDevice);

            return deviceModel;
        }

        public DeviceEntity ToEntities()
        {
            var deviceEntity = new DeviceEntity()
            {
                SerialNumber = SerialNumber,
                Brand = Brand,
                Model = Model,
                IdDeviceType = (int)TypeDeviceValue
            };

            return deviceEntity;
        }

        #endregion

        #region Internal Method

        internal static TypeDeviceModel GetTypeDeviceData(Enumerators.DeviceTypes deviceType, int IdDevice)
        {
            switch (deviceType)
            {
                case Enumerators.DeviceTypes.WATER_METER:
                    return WaterMeterModel.FromEntity(WaterMeterEntity.Load(IdDevice));
                case Enumerators.DeviceTypes.LIGHT_METER:
                    return LightMeterModel.FromEntity(LightMeterEntity.Load(IdDevice));
                case Enumerators.DeviceTypes.GATEWAY:
                    return GatewayModel.FromEntity(GatewayEntity.Load(IdDevice));
                default:
                    return null;
            }
        }

        #endregion
    }
}
