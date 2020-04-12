using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class Koch : Fractal
{
    public Koch(Color startColor, Color endColor, int iteration, float height, float width) :
        base(startColor, endColor, iteration, height, width) { }

    public override void Draw(Graphics graph)
    {
        PointF pointLeftEnd = new PointF(0, 8 * pictureHeight / 10);
        PointF pointRightEnd = new PointF(pictureWidth, 8 * pictureHeight / 10);
        DrawKoch(graph, pointLeftEnd, pointRightEnd, 1);
    }

    void DrawKoch(Graphics graph, PointF pLineLeft, PointF pLineRight, int currentIteration)
    {
        pen.Color = GenerateGradientColor(currentIteration);

        if (currentIteration == iteration)
            graph.DrawLine(pen, pLineLeft, pLineRight);
        else
        {
            PointF pCurveLeft = new PointF(
                pLineLeft.X + (pLineRight.X - pLineLeft.X) * 1 / 3,
                pLineLeft.Y + (pLineRight.Y - pLineLeft.Y) * 1 / 3
                );

            PointF pCurveRight = new PointF(
                pLineLeft.X + (pLineRight.X - pLineLeft.X) * 2 / 3,
                pLineLeft.Y + (pLineRight.Y - pLineLeft.Y) * 2 / 3
                );

            PointF pCurveTop = new PointF(
                (float)(pCurveLeft.X + (pCurveRight.X - pCurveLeft.X) * Math.Cos(Math.PI / 3) - Math.Sin(5 * Math.PI / 3) * (pCurveRight.Y - pCurveLeft.Y)),
                (float)(pCurveLeft.Y + (pCurveRight.X - pCurveLeft.X) * Math.Sin(5 * Math.PI / 3) + Math.Cos(Math.PI / 3) * (pCurveRight.Y - pCurveLeft.Y))
                );

            DrawKoch(graph, pLineLeft, pCurveLeft, currentIteration + 1);
            DrawKoch(graph, pCurveLeft, pCurveTop, currentIteration + 1);
            DrawKoch(graph, pCurveTop, pCurveRight, currentIteration + 1);
            DrawKoch(graph, pCurveRight, pLineRight, currentIteration + 1);
        }
    }
}
