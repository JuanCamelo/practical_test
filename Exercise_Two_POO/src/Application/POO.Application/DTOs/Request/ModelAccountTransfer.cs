﻿using System.Text.Json.Serialization;

namespace POO.Application.DTOs.Request
{
    public class ModelAccountTransfer
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [JsonPropertyName("document")]
        public int Document { get; set; }
    }
}
