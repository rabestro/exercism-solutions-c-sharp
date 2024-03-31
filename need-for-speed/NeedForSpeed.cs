using System;

class RemoteControlCar
{
    public int Speed { get; }
    public int BatteryDrain { get; }
    private int _distanceDriven;
    private int _battery = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _battery < BatteryDrain;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (BatteryDrained())
            return;

        _distanceDriven += Speed;
        _battery -= BatteryDrain;
    }

    public static RemoteControlCar Nitro() => new(50, 4);
}

class RaceTrack(int distance)
{
    public bool TryFinishTrack(RemoteControlCar car) => 100 / car.BatteryDrain * car.Speed >= distance;
}
