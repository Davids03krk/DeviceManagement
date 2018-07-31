using DeviceManagement.Business.Entities;
using DeviceManagement.Business.Functions;

namespace DeviceManagement.Model.Device
{
    public class WaterMeterModel : TypeDeviceModel
    {
        #region Public Methods

        public static WaterMeterModel FromEntity(WaterMeterEntity waterMeterEntity)
        {
            var waterMeterModel = new WaterMeterModel()
            {
                IdDevice = waterMeterEntity.IdDevice,
                TypeDevice = Enumerators.DeviceTypes.WATER_METER
            };

            return waterMeterModel;
        }

        public WaterMeterEntity ToEntities()
        {
            var waterMeterEntity = new WaterMeterEntity()
            {
                IdDevice = IdDevice
            };

            return waterMeterEntity;
        }

        #endregion
    }
}
