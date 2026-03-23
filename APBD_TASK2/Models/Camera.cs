namespace APBD_TASK2.Models;

public class Camera : Equipment
{
    public int MegaPixels { get; set; }
    public bool IsDigital { get; set; }

    public Camera(string name, int megaPixels, bool isDigital) : base(name)
    {
        MegaPixels = megaPixels;
        IsDigital = isDigital;
    }

    public override string ToString()
    {
        return $"Camera: {base.ToString()} | MP: {MegaPixels} | Digital: {IsDigital}";
    }
}