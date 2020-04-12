using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

abstract public class Fractal
{
    protected Pen pen;
    protected Color startColor, endColor;
    protected int iteration;
    protected float pictureHeight, pictureWidth;

    protected Fractal(Color startColor, Color endColor, int iteration, float height, float width)
    {
        this.startColor = startColor;
        this.endColor = endColor;
        this.iteration = iteration;
        pictureHeight = height;
        pictureWidth = width;
        pen = new Pen(startColor, 1);
    }

    abstract public void Draw(Graphics graph);

    protected Color GenerateGradientColor(int currentIteration)
    {
        if (currentIteration == 1)
            return startColor;
        else if (currentIteration == iteration)
            return endColor;
        else
        {
            Color res = new Color();
            var rAverage = startColor.R + ((endColor.R - startColor.R) * currentIteration / iteration);
            var gAverage = startColor.G + ((endColor.G - startColor.G) * currentIteration / iteration);
            var bAverage = startColor.B + ((endColor.B - startColor.B) * currentIteration / iteration);
            res = Color.FromArgb(rAverage, gAverage, bAverage);
            return res;
        }
    }
}
