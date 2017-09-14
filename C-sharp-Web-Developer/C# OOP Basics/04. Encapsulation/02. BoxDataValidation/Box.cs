using System;

public class Box
{
    // the second Project wants to set private set-ers, so that's why this code is different from what they wants from  us in Project 01. I Modified it!
    private double lenght;
    private double width;
    private double height;

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }

    public double Lenght
    {
        get { return lenght; }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            lenght = value;
        }
    }

    public double Width
    {
        get { return width; }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    public double Height
    {
        get { return height; }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            height = value; 
        }
    }

    public double Surfacearea()
    {
        return (2 * lenght * width) + LateralSurfacearea();
    }

    public double LateralSurfacearea()
    {
        return (2 * lenght * height) + (2 * width * height);
    }

    public double Volume()
    {
        return lenght * width * height;
    }
}