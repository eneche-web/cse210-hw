using System;
using System.Collections.Generic;


public class Video
{
    private string _title;
    private string _autor;
    private int _lengthInSeconds;
    private List<Comment> _comment = new List<Comment>();


    public Video(string title, string autor, int LengthInSeconds)
    {
        _title = title;
        _autor = autor;
        _lengthInSeconds = LengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comment.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comment.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAutor()
    {
        return _autor;
    }

    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    public List<Comment>GetComments()
    {
        return _comment;
    }
}