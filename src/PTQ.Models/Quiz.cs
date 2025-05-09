namespace PTQ.Models;

public class Quiz(int id, string name, int potatoTeacherId, string pathFile)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int PotatoTeacherId { get; set; } = potatoTeacherId;
    public string PathFile { get; set; } = pathFile;
}