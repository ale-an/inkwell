﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.Auth;

public class LoginForm
{
    public string Email { get; set; }
    public string Password { get; set; }
}