using System.Drawing;
using Morysoft.MorySnip.Classes.Layers;

namespace Morysoft.MorySnip.Classes;

public class EditorStep
{
    public EditorStep(Bitmap image, int lastNumber, List<Layer> layers)
    {
        this.Image = image ?? throw new ArgumentNullException(nameof(image));
        this.LastNumber = lastNumber;
        this.Layers = layers ?? throw new ArgumentNullException(nameof(layers));
    }

    public Bitmap Image { get; set; }

    public int LastNumber { get; set; }

    public List<Layer> Layers { get; set; }
}
