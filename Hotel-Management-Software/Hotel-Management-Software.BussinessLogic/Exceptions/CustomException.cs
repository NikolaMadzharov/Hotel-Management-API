﻿namespace Hotel_Management_Software.BBL.Exceptions;

public class CustomException:Exception
{
    public int StatusCode { get; }

    public CustomException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
