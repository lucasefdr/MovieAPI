﻿namespace MovieAPI.Models;

public class Section
{
    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public int MovieTheaterId { get; set; }
    public virtual MovieTheater MovieTheater { get; set; }
}