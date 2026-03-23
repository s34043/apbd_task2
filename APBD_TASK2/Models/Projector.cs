namespace APBD_TASK2.Models;

public class Projector : Equipment
{
    public string Resolution { get; set; }
    public int BrightnessLumens { get; set; }

    public Projector(string name, string resolution, int brightnessLumens) : base(name)
    {
        Resolution = resolution;
        BrightnessLumens = brightnessLumens;
    }

    public override string ToString()
    {
        return $"Projector: {base.ToString()} | Resolution: {Resolution} | Brightness: {BrightnessLumens} lumens";
    }
}