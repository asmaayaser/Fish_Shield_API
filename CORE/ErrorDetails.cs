﻿namespace CORE
{
    public record ErrorDetails(int StatusCode,string Message);

    //public class ErrorDetails
    //{
    //    public int StatusCode { get; init; }
    //    public string Message { get; init; }
    //    public override bool Equals(object? obj)
    //    {
    //        return base.Equals(obj);
    //    }
    //    public override int GetHashCode()
    //    {
    //        return base.GetHashCode();
    //    }
    //    public override string ToString()
    //    {
    //        return base.ToString();
    //    }
    //}
}
