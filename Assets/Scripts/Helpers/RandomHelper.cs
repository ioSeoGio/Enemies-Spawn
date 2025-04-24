using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using System;
using UnityEditor;

public static class RandomHelper
{
    private readonly static System.Random _random = new System.Random();
    private const int MinRandom = 0;
    private const int MaxRandom = 100;

    public static bool IsRandomEventHappened(float chance)
    {
        return GetRandomNumber(MinRandom, MaxRandom + 1) <= chance;
    }

    public static int GetRandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }
}