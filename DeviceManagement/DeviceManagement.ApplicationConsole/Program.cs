using DeviceManagement.Business.Entities;
using DeviceManagement.Business.Functions;
using DeviceManagement.Model.Device;
using System;

namespace DeviceManagement.ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool insertOther = false;

            do
            {
                try
                {
                    var device = new DeviceModel()
                    {
                        TypeDeviceValue = InsertTypeDevice(),
                        SerialNumber = InsertSerialNumber(),
                        Brand = InsertBrand(),
                        Model = InsertModel()
                    };

                    int idDevice = DeviceEntity.Create(device.ToEntities());

                    switch (device.TypeDeviceValue)
                    {
                        case Enumerators.DeviceTypes.WATER_METER:
                            var waterMeter = new WaterMeterModel()
                            {
                                IdDevice = idDevice,
                                TypeDevice = device.TypeDeviceValue
                            };

                            WaterMeterEntity.Create(waterMeter.ToEntities());

                            break;
                        case Enumerators.DeviceTypes.LIGHT_METER:
                            var lightMeter = new LightMeterModel()
                            {
                                IdDevice = idDevice,
                                TypeDevice = device.TypeDeviceValue
                            };

                            LightMeterEntity.Create(lightMeter.ToEntities());

                            break;
                        case Enumerators.DeviceTypes.GATEWAY:
                            var gateway = new GatewayModel()
                            {
                                IdDevice = idDevice,
                                TypeDevice = device.TypeDeviceValue,
                                Ip = InsertIp(),
                                Port = InsertPort()
                            };

                            GatewayEntity.Create(gateway.ToEntities());

                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\n\t" + ex.Message + ". Review the entered data");
                }                

                Console.Write("\n\n\n\tPress Y if you want to insert a new device: ");
                string opc = Console.ReadLine().ToString();
                insertOther = opc == "Y" || opc == "y";
                Console.Write("\n\n\n");

            } while (insertOther);
        }
        
        private static Enumerators.DeviceTypes InsertTypeDevice()
        {
            Console.WriteLine("\n\t1.- Water Meter");
            Console.WriteLine("\t2.- Light Meter");
            Console.WriteLine("\t3.- Gateway");

            Console.Write("\n\tSelect the type of device you want to create: ");
            return (Enumerators.DeviceTypes)Enum.Parse(typeof(Enumerators.DeviceTypes), Console.ReadLine().ToString());
        }

        private static string InsertModel()
        {
            Console.Write("\n\tInsert the model: ");
            return Console.ReadLine().ToString();
        }

        private static string InsertBrand()
        {
            Console.Write("\n\tInsert the brand: ");
            return Console.ReadLine().ToString();
        }

        private static string InsertSerialNumber()
        {
            Console.Write("\n\tInsert the serial number: ");
            return Console.ReadLine().ToString();
        }
        
        private static string InsertIp()
        {
            Console.Write("\n\tInsert the ip: ");
            return Console.ReadLine().ToString();
        }

        private static string InsertPort()
        {
            Console.Write("\n\tInsert the port: ");
            return Console.ReadLine().ToString();
        }
    }
}
