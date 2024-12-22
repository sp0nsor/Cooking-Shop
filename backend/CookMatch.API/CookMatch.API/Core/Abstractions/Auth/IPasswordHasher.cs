﻿namespace CookMatch.API.Core.Abstractions.Auth
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool Verify(string password, string passwordHash);
    }
}