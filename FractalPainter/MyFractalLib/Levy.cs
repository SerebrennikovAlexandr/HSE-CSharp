using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class Levy : Fractal
{
    public Levy(Color startColor, Color endColor, int iteration, float height, float width) :
        base(startColor, endColor, iteration, height, width) { }

    public override void Draw(Graphics graph)
    {
        PointF pointLeftEnd = new PointF(pictureWidth / 4, 8 * pictureHeight / 10);
        PointF pointRightEnd = new PointF(3 * pictureWidth / 4, 8 * pictureHeight / 10);
        DrawLevy(graph, pointLeftEnd, pointRightEnd, 1);
    }

    void DrawLevy(Graphics graph, PointF p1, PointF p2, int currentIteration)
    {
        if (currentIteration == iteration)
        {
            pen.Color = GenerateGradientColor(currentIteration);
            graph.DrawLine(pen, p1, p2);
        }
        else
        {
            PointF pNew = new PointF();
            pNew.X = (p1.X + p2.X) / 2 + (p2.Y - p1.Y) / 2;
            pNew.Y = (p1.Y + p2.Y) / 2 - (p2.X - p1.X) / 2;
            DrawLevy(graph, p1, pNew, currentIteration + 1);
            DrawLevy(graph, pNew, p2, currentIteration + 1);
        }
    }
}