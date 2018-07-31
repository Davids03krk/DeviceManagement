using DeviceManagement.Business.Functions;

namespace DeviceManagement.Model.Device
{
    public abstract class TypeDeviceModel
    {
        #region Properties

        public int IdDevice { get; set; }
        public Enumerators.DeviceTypes TypeDevice { get; set; }

        #endregion
    }
}
