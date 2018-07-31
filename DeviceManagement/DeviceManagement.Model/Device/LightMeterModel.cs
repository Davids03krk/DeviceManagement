using DeviceManagement.Business.Entities;
using DeviceManagement.Business.Functions;

namespace DeviceManagement.Model.Device
{
    public class LightMeterModel : TypeDeviceModel
    {
        #region Public Methods

        public static LightMeterModel FromEntity(LightMeterEntity lightMeterEntity)
        {
            var lightMeterModel = new LightMeterModel()
            {
                IdDevice = lightMeterEntity.IdDevice,
                TypeDevice = Enumerators.DeviceTypes.LIGHT_METER
            };

            return lightMeterModel;
        }

        public LightMeterEntity ToEntities()
        {
            var lightMeterEntity = new LightMeterEntity()
            {
                IdDevice = IdDevice
            };

            return lightMeterEntity;
        }

        #endregion
    }
}