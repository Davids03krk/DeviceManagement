CREATE TABLE [dbo].[DEVICE] (
    [IdDevice]     INT        NOT NULL,
    [SerialNumber] NCHAR (10) NOT NULL,
    [Brand]        NCHAR (10) NULL,
    [Model]        NCHAR (10) NULL,
    [IdDeviceType] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDevice] ASC),
    CONSTRAINT [FK_DEVICE_DEVICETYPE] FOREIGN KEY ([IdDeviceType]) REFERENCES [dbo].[DEVICE_TYPE] ([IdDeviceType])
);

