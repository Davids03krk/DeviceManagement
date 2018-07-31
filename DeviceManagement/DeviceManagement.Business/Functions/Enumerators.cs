using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Business.Functions
{
    /// <summary>
    /// Class to store all enumerators for functions
    /// </summary>
    public static class Enumerators
    {
        /// <summary>
        /// Type of Device
        /// </summary>
        public enum DeviceTypes
        {
            [Display(Name = "WATER_METER", Description = "Water meter")]
            WATER_METER = 1,
            [Display(Name = "LIGHT_METER", Description = "Light meter")]
            LIGHT_METER = 2,
            [Display(Name = "GATEWAY", Description = "Gateway")]
            GATEWAY = 3
        }
    }
}
