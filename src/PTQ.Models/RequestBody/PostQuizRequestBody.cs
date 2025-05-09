namespace PTQ.API;

public class PostQuizRequestBody(string name, string potatoTeacherName, string path)
{
    public string Name { get; set; } = name;
    public string PotatoTeacherName { get; set; } = potatoTeacherName;
    public string Path { get; set; } = path;
}