using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRandom : System.Random
{
    double prevSample = double.NaN;
    protected override double Sample()
    {
        if (!double.IsNaN(prevSample))
        {
            double result = prevSample;
            prevSample = double.NaN;
            return result;
        }

        double u, v, s;
        do
        {
            u = 2 * base.Sample() - 1;
            v = 2 * base.Sample() - 1;  
            s = u * u + v * v;
        }
        while (u <= -1 || v <= -1 || s >= 1 || s == 0);
        double r = Math.Sqrt(-2 * Math.Log(s) / s);
        prevSample = r * v;
        return r * u;
    }

    public override int Next(int minValue, int maxValue)
    {
        double d = maxValue - minValue;
        d /= 2.0;
        int res;
        do
        {
            res = (int)(Sample() * d + d + minValue);
        }
        while (res < minValue || res > maxValue);
        return res;
    }

    public double NextDouble(double minValue, double maxValue)
    {
        double d = maxValue - minValue;
        d /= 2.0;
        double res;
        do
        {
            res = Sample() * d + d + minValue;
        }
        while (res < minValue || res > maxValue);
        return res;
    }
}
