﻿namespace PTQ.Repositories;

public class GetAllTestResponseBody(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}